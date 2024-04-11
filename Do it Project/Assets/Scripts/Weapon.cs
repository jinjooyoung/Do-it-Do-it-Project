// 추후 무기가 만들고 에니메이션 작업이 끝나면 playerscipt와 연결

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{

    public enum Type { Melee, Eange } // 추후 무기 리스트 정하여 선언
    public Type type;
    public int damage;
    public float rate;
    public BoxCollider meleeArea;
    public TrailRenderer trailRenderer;



    public void Use()
    {
        if (type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
    }

    // IEnumerator : 열거형 함수 클래스
    IEnumerator Swing()
    {
        // 중요한 개념인 코루틴
        // 기존 : Use() 메인루틴 -> Swing() 서브루틴 -> Use() 메인루틴 (교차실행)
        // 코루틴 : Use() 메인루틴 + Swing() 코루틴 Co - (동시실행)

        // yield : 결과를 전달하는 키워드, 여러 개 사용해 시간차 로직 구현가능

        //1
        yield return new WaitForSeconds(0.1f); // 0.1 초 대기
        meleeArea.enabled = true;
        // trailEffect.enabled = true;

        //2
        yield return new WaitForSeconds(0.3f); // 0.3 초 대기
        meleeArea.enabled = false;

        //3
        yield return new WaitForSeconds(0.3f); // 0.3 초 대기
                                               // trailEffect.enabled = false;

        bool fDown; // 공격버튼
        bool isFireReady = true; // 공격가능 여부

        Weapon equipWeapon; // GameObject -> Weapon 스크립트로 변경
        float fireDelay; // 공격 딜레이 타임

        void Update()
        {
            Attack();
        }

        void GetInput()
        {
            fDown = Input.GetButtonDown("Fire1");
        }

        void Move()
        {
            // 스왑 및 공격 시 못움직이게
            //   if (isSwap || !isFireReady)
            //      moveVec = Vector3.zero;
        }

        // 이번 스크립트 중요부분
        void Attack()
        {
            // 공격할 조건만 플레이어에 두고, 공격로직은 무기에 위임한다.
            if (equipWeapon == null)
                return;

            fireDelay += Time.deltaTime;
            isFireReady = equipWeapon.rate < fireDelay;

            //   if (fDown && isFireReady && !isDodge && !isSwap)
            {
                equipWeapon.Use();
                //   anim.SetTrigger("doSwing");
                fireDelay = 0;
            }

        }


        void Swap()
        {
            // equipWeapon이 GameObject -> Weapon으로 바뀌기에 맞춰서 바꿔줍니다


            // if ((sDown1 || sDown2 || sDown3) && !isJump && !isDodge)
            {
                if (equipWeapon != null)
                    equipWeapon.gameObject.SetActive(false);

                //   equipWeaponIndex = weaponIndex;

                // weapons[weaponIndex] -> weapons[weaponIndex].GetComponent<Weapon>();
                //  equipWeapon = weapons[weaponIndex].GetComponent<Weapon>();

                // equipWeapon.SetActive(true) -> equipWeapon.gameObject.SetActive(true);
                equipWeapon.gameObject.SetActive(true);

                //   anim.SetTrigger("doSwap");


                // 스왑 중
                //   isSwap = true;
                Invoke("SwapOut", 0.4f);

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerscript player = other.GetComponent<playerscript>(); // PlayerScript 로 연결
    }

}
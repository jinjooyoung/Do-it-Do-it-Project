using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerQ : MonoBehaviour
{
    public float speed = 8.0f;
    public float attackRange = 1f;      // 공격 콜라이더가 플레이어를 기준으로 얼마나 떨어져서 생성될 것인지 그 거리에 대한 변수 (즉, 공격 거리)
    public float attackCooldown = 1.0f;   //공격 쿨타임 (임의로 지정해둠)
    public GameObject attackPrefab; // 타격 콜라이더로 사용할 프리팹

    private float curTime = 0f; // 현재 쿨다운 시간
    private Vector2 lastMoveDirection = Vector2.right; // 플레이어의 마지막 이동 방향, 기본값은 오른쪽
    private Rigidbody2D rb;
    private Animator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, ySpeed, 0);
        rb.velocity = newVelocity;      //위는 다 이동 관련 코드

        // 플레이어의 마지막 이동 방향 업데이트
        if (xSpeed != 00 || ySpeed != 00)   //플레이어의 위치가 0이 아닐 때. 즉 이동하였을 때
        {
            lastMoveDirection = newVelocity.normalized;   
          
        }

        // 공격 쿨다운 감소 및 입력 처리
        if (curTime > 0) 
        {
            curTime -= Time.deltaTime;
        }
        else if (Input.GetMouseButtonDown(0))      
        {
            // 타격 콜라이더 생성
            GameObject attack= Instantiate(attackPrefab, 
                transform.position + (Vector3)lastMoveDirection * attackRange, Quaternion.identity);
            //닷지 게임의 BulletSpawner코드 참고
            Destroy(attack, 15* Time.deltaTime);


            // 공격 쿨다운 설정
            curTime = attackCooldown;
            //공격이 끝났으니 쿨타임을 부여해줘야함
        }
    }
}


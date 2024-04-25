 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public enum Type { Melee, Eange }
public class playerscript : MonoBehaviour
{
    public float speed;
    public int itemCount;
    public float attackTime = 0.3f;          // 공격 쿨타임
    public float attackTimer;                   // 공격 쿨타임 계산용
    public bool isAttack;
    public Type weaponType = Type.Melee;
    public BoxCollider attackArea;
    float hAxis;
    float vAxis;

    /*bool WDown;
    bool jump;


    bool isJump;    //기능 생략*/

    Vector3 moveVec;

    Rigidbody rb; // 케릭터를 움직이기 위해 선언
    //Animator anim;

    GameObject nearObject;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); //리지드바디 컴포넌트에 rb할당
        attackArea = GetComponent<BoxCollider>();
        attackArea.enabled = false;
        //anim = GetComponentInChildren<Animator>();  //애니메이터 컴포넌트에 anim할당
    }
    void Update()
    {
        GetInput();
        Move();
        Turn();
        //Jump();
        Attack();
        //함수 불러오기 (밑에 함수)
    }


    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        /*WDown = Input.GetButton("wolk");
        jump = Input.GetButtonDown("Jump");*/

        //Axis를 불러와서 변수에 저장

    }
    

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;  //실질적인 이동 구현

        transform.position += moveVec * speed * Time.deltaTime; //렌더

     //   anim.SetBool("isRun", moveVec != Vector3.zero);     //이동속도가 zero가 아닐 때 이동 애니메이션
        //anim.SetBool("isWolk", WDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);     //보는 화면으로 회전
    }

    private void Attack()
    {
        if(weaponType == Type.Melee)
        {
            attackArea.enabled = isAttack;
        }
        else if(weaponType == Type.Eange)
        {
            //Eange();
        }


        if (isAttack == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isAttack = true;
                attackTimer = attackTime;
            }
        }
        else // isAttack == true
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                isAttack = false;
            }
        }
    }

    //탑뷰 게임이라서 점프는 생략

    /*void Jump() // 점프
    {
        if (jump && !isJump) // ! 부정문 bool 값만 가능
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            anim.SetBool("triggerJump", true);
            isJump = true;
        }
    }*/


   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            anim.SetBool("triggerJump", false);
            isJump = false;
        }
    }*/


}
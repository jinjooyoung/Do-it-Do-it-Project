using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 8.0f;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //이동
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed); //2D 게임이므로 Vector3를 쓸 필요가 없음
        //리지드바디의 속도에 newVelocity 할당
        rb.velocity = newVelocity;

        playerAnimator.SetFloat("HorizontalAxis", Input.GetAxis("Horizontal"));


        //if (rb.velocity.x! < 0)
        //{
        //    playerAnimator.SetBool("Walk_Left", true);
        //}
        //else
        //{
        //    playerAnimator.SetBool("Walk_Left", false);
        //}
    }
}

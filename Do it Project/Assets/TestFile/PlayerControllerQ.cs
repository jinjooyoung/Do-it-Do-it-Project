using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerQ : MonoBehaviour
{
    public float speed = 8.0f;
    public float attackRange = 1.5f;      // 공격 콜라이더가 플레이어를 기준으로 얼마나 떨어져서 생성될 것인지 그 거리에 대한 변수 (즉, 공격 거리)
    public float attackCooldown = 1.0f;   //공격 쿨타임 (임의로 지정해둠)
    public GameObject attackColliderPrefab; // 타격 콜라이더로 사용할 프리팹

    private float curTime = 0f; // 현재 쿨다운 시간
    private Vector2 lastMoveDirection = Vector2.right; // 플레이어의 마지막 이동 방향, 기본값은 오른쪽
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
        rb.velocity = newVelocity;      //위는 다 이동 관련 코드

        // 플레이어의 마지막 이동 방향 업데이트
        if (newVelocity != Vector2.zero)   //플레이어의 위치가 0이 아닐 때. 즉 이동하였을 때
        {
            lastMoveDirection = newVelocity.normalized;   
            //마지막으로 이동한 방향을 저장할 벡터 변수인 lastMoveDirection에 newVelocity(이동할때 사용한 벡터.
            //즉 지금 이동한 위치라고 볼 수 있음)의 normalized(벡터의 정규화.
            //쉽게 말해서 4/29 게임엔진과 입문 수업시간에 배웠던 방향벡터로 변환해줌.
            //예를 들어서 (3,0)으로 이동했다고 한다면 (1,0)*3이므로 여기에서(1,0)에 해당하는 부분을 구해준다고 볼 수 있음.
            //정말 요약해서 마지막으로 이동했던 방향을 구해줌)
        }

        // 공격 쿨다운 감소 및 입력 처리
        if (curTime > 0)      //쿨타임이 0보다 클 때. 즉, 쿨타임에 걸려있을 때 = 공격을 못하는 상황일 때
        {
            curTime -= Time.deltaTime;   // 델타타임을 빼주면서 쿨타임을 감소시킴
        }
        else if (Input.GetMouseButtonDown(0))      
            //else이므로 쿨타임이 0보다 작거나 같을 때.
            //즉, 쿨타임에 걸려있지 않을 때 = 공격이 가능한 상황일 때 + (마우스 좌클릭 입력을 받았을 때)
        {
            // 타격 콜라이더 생성
            GameObject attackCollider = Instantiate(attackColliderPrefab, 
                transform.position + (Vector3)lastMoveDirection * attackRange, Quaternion.identity);
            //닷지 게임의 BulletSpawner코드 참고

            Destroy(attackCollider, 1*Time.deltaTime); // 0.2초 후 타격 콜라이더 파괴      
            //공격이 지속되는 시간 0.2초로 임의로 지정해둠. 0.2초 동안 공격이 진행되고 콜라이더가 사라짐 = 공격이 끝남

            // 공격 쿨다운 설정
            curTime = attackCooldown;
            //공격이 끝났으니 쿨타임을 부여해줘야함
        }
    }
}


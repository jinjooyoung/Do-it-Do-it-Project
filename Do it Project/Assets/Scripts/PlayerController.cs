using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float projectileSpeed = 10f;
    public GameObject projectilePrefab;

    private Rigidbody2D rb;
    public Animator animator;                   //애니메이션!!
    private string currentAnimation = "";       //애니메이션!!

    private bool isShooting = false;
    private float shootTimer = 0f;
    public float shootInterval = 0.3f; // 투사체 발사 간격 (초)

    private Vector2 shootDirection = Vector2.zero;

    public GameManager gameManager;
    public bool isPlayingSequence = false;
    public bool isBlockMoveSequence = false;
    public int MoveTemp = 0;
    bool isAni = false;
    public GameObject UIManager;

    Vector2 moveDirection;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();   //애니메이션!!
    }

    void ChangeAnimation(string animation, float crossfade = 0.2f)  //애니메이션!!
    {
        if(currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossfade);
        }
    }

    private void Update()
    {
        if (isPlayingSequence)
            return;

        // 플레이어 이동
        moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) moveDirection.x = -1;

        else if (Input.GetKey(KeyCode.D)) moveDirection.x = 1;
        
        if (Input.GetKey(KeyCode.W)) moveDirection.y = 1;
        
        else if (Input.GetKey(KeyCode.S)) moveDirection.y = -1;
        //이동키를 하나만 눌렀을 경우
        if(moveDirection.x == -1 && moveDirection.y != -1 && moveDirection.y != 1) ChangeAnimation("LeftMove");
        if(moveDirection.x == 1 && moveDirection.y != -1 && moveDirection.y != 1) ChangeAnimation("RightMove");
        if (moveDirection.y == -1 && moveDirection.x != -1 && moveDirection.x != 1) ChangeAnimation("FrontMove");
        if (moveDirection.y == 1 && moveDirection.x != -1 && moveDirection.x != 1) ChangeAnimation("BackMove");
        //이동키를 두개를 같이 눌렀을 경우
        if (moveDirection.x == 1 && moveDirection.y == -1) ChangeAnimation("RightMove");
        if (moveDirection.x == 1 && moveDirection.y == 1) ChangeAnimation("RightMove");
        if (moveDirection.y == -1 && moveDirection.x == -1) ChangeAnimation("LeftMove");
        if (moveDirection.y == 1 && moveDirection.x == -1) ChangeAnimation("LeftMove");
        //두개의 공격키를 눌렀을 경우의 오류수정

            rb.velocity = moveDirection.normalized * moveSpeed;

        // 투사체 발사
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartShooting(Vector2.left);
            animator.SetBool("LeftAttack", true);
            animator.SetBool("RightAttack", false);
            animator.SetBool("BackAttack", false);
            animator.SetBool("FrontAttack", false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartShooting(Vector2.right);
            animator.SetBool("RightAttack", true);
            animator.SetBool("LeftAttack", false);
            animator.SetBool("BackAttack", false);
            animator.SetBool("FrontAttack", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartShooting(Vector2.up);
            animator.SetBool("BackAttack", true);
            animator.SetBool("LeftAttack", false);
            animator.SetBool("RightAttack", false);
            animator.SetBool("FrontAttack", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartShooting(Vector2.down);
            animator.SetBool("FrontAttack", true);
            animator.SetBool("LeftAttack", false);
            animator.SetBool("RightAttack", false);
            animator.SetBool("BackAttack", false);
        }

        // 화살표 키가 눌리지 않았을 때 발사 중지
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) &&
            !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            StopShooting();
        }
        if((moveDirection.x != 1 && moveDirection.x != -1 && moveDirection.y != 1 && moveDirection.y!= -1 && !Input.GetKey(KeyCode.LeftArrow) 
            && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)))
        {
            ChangeAnimation("Idle");
        }
        //이동과 공격을 같이 하고 나서 공격을 멈췄을 때의 오류수정
        if(shootDirection.x == -1 && moveDirection.x == -1 )
        {
            if (isAni == false && moveDirection.x == -1)
            {
                //ChangeAnimation("Idle(2)");
            }
        }
        // 발사 간격 체크
        if (isShooting)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootInterval)
            {
                ShootProjectile();
                shootTimer = 0f;

            }
        }
    }

    void StartShooting(Vector2 direction)
    {
        isShooting = true;
        isAni = true;
        shootDirection = direction; // 발사 방향 설정
        shootTimer = 0f; // 총알이 바로 발사되도록 타이머 초기화
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(shootDirection.x, shootDirection.y, 0) * 0.2f, Quaternion.identity);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectile.GetComponent<Bullet>().bullettype = Bullet.BULLETTYPE.PLAYER;
            if (projectileRb != null)
            {
                projectileRb.velocity = shootDirection * projectileSpeed;
            }
            Destroy(projectile, 1.0f);
        }
    }

    void StopShooting()
    {
        isShooting = false;
        isAni = false;
        shootTimer = 0f;
        animator.SetBool("LeftAttack", false);
        animator.SetBool("RightAttack", false);
        animator.SetBool("BackAttack", false);
        animator.SetBool("FrontAttack", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if(collision.gameObject.tag == "Door")
        {
            DoorObject temp = collision.gameObject.GetComponent<DoorObject>();
            if(temp != null)
            {
                if(temp.DoorBlockIndex == gameManager.PlayerBlockIndex)
                {                   
                    Invoke("MoveIndexSet", 2.0f);
                    MoveTemp = temp.MoveToIndex;
                    StartMovingTowardsTarget(gameManager.MapBlock[MoveTemp].transform);
                    gameManager.MoveBlock(temp.MoveToIndex);
                    isPlayingSequence = true;
                    isBlockMoveSequence = true;
                }               
            }
            else
            {
                Debug.LogError("Door 컴포넌트가 없음");
            }
        }
       /* if (collision.gameObject.tag == "Trap")  //보스전 시작
        {
            UIManager.gameObject.GetComponent<UIManager>().GotoBoss();
        }*/
    }

    // 연출 시작 시 호출할 함수
    public void StartMovingTowardsTarget(Transform target)
    {
        // 목표 위치의 1/5 위치를 계산합니다.
        Vector3 destination = Vector3.Lerp(transform.position, target.position, 0.3f);

        // DOTween을 사용하여 부드럽게 목표 위치의 1/5 위치로 이동합니다.
        transform.DOMove(destination, 1.0f).SetEase(Ease.Linear);
    }

    public void MoveIndexSet()
    {
        gameManager.PlayerBlockIndex =  MoveTemp;
        isPlayingSequence = false;
        isBlockMoveSequence = false;
;
    }

    public void Die()
    {
        Debug.Log("플레이어 사망");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pond")
        {
            UIManager.gameObject.GetComponent<UIManager>().Clear();
        }
    }
}


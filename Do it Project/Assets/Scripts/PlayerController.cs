using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float projectileSpeed = 10f;
    public GameObject projectilePrefab;

    private Rigidbody2D rb;
    public Animator animator;

    private bool isShooting = false;
    private float shootTimer = 0f;
    public float shootInterval = 0.3f; // 투사체 발사 간격 (초)

    private Vector2 shootDirection = Vector2.zero;

    public GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 플레이어 이동
        Vector2 moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -1;
        }

        rb.velocity = moveDirection.normalized * moveSpeed;

        // 투사체 발사
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartShooting(Vector2.left);
            animator.SetInteger("CharacterMoveState", 3);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartShooting(Vector2.right);
            animator.SetInteger("CharacterMoveState", 2);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartShooting(Vector2.up);
            animator.SetInteger("CharacterMoveState", 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartShooting(Vector2.down);
            animator.SetInteger("CharacterMoveState", 0);
        }

        // 화살표 키가 눌리지 않았을 때 발사 중지
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) &&
            !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            StopShooting();
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
        shootDirection = direction; // 발사 방향 설정
        shootTimer = 0f; // 총알이 바로 발사되도록 타이머 초기화
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(shootDirection.x, shootDirection.y, 0) * 0.2f, Quaternion.identity);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
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
        shootTimer = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "DOOR")
        {
            gameManager.MoveBlock(2);
        }

    }
}


using System.Collections;//
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int BlockIndex = 1;
    public float moveSpeed = 5f; // 적의 이동 속도
    public GameObject missilePrefab;
    public Transform player;
    public float fireRate = 1f; // 발사 속도 (초당 발사 횟수)
    public float fireTime = 0f;

    public GameManager gameManager;

    public Animator monsteranimator;
    private string currentAnimation = "";
    public GameObject slaimPf;
    public GameObject mousePf;
    public GameObject dogPf;
    bool isAniStart = false;
    //사운드
    public GameObject monsterAttack;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }
    void ChangeAnimation(string animation, float crossfade = 0.2f)  //애니메이션!!
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            if (slaimPf != null) monsteranimator.CrossFade(animation, crossfade);
            if (mousePf != null) monsteranimator.CrossFade(animation, crossfade);
            if (dogPf != null) monsteranimator.CrossFade(animation, crossfade);
        }
    }

    void Update()
    {
        if (gameManager.PlayerBlockIndex != BlockIndex)
            return;

        isAniStart = true;
        if(isAniStart == true)
        {
           monsteranimator = GetComponent<Animator>();
        }
        // 플레이어 방향으로 이동
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        if (transform.position.x < player.position.x)
        {
            ChangeAnimation("RightMove");
            if (slaimPf != null) monsteranimator.SetInteger("move", 1);
            if (mousePf != null) monsteranimator.SetInteger("move", 1);
            if (dogPf != null) monsteranimator.SetInteger("move", 1);
        }
        if (transform.position.x > player.position.x)
        {
            ChangeAnimation("LeftMove");
            if (slaimPf != null) monsteranimator.SetInteger("move", 2);
            if (mousePf != null) monsteranimator.SetInteger("move", 2);
            if (dogPf != null) monsteranimator.SetInteger("move", 2);
        }
        fireTime += Time.deltaTime;

        if(fireTime >= fireRate)
        {
            Shoot();
            fireTime = 0.0f;
        }
    }

    void Shoot()
    {
        monsterAttack.GetComponent<AudioSource>().Play();
        // 미사일 프리팹을 인스턴스화하여 발사 위치에서 생성합니다.
        GameObject temp = Instantiate(missilePrefab, transform.position, Quaternion.identity);

        // 생성된 미사일을 플레이어를 향해 발사합니다.
        Vector2 direction = (player.position - transform.position).normalized;
        temp.GetComponent<Rigidbody2D>().velocity = direction; // 미사일의 초기 속도 설정
        temp.GetComponent<Bullet>().bullettype = Bullet.BULLETTYPE.ENEMY;
        Destroy(temp, 10.0f);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}

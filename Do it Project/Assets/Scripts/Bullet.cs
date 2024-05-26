using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BULLETTYPE
    {
        PLAYER,
        ENEMY,
        //BOSSENEMY
    }

    public int Damage = 1;

    public BULLETTYPE bullettype = BULLETTYPE.PLAYER;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && bullettype == BULLETTYPE.PLAYER)
        {
            collision.gameObject.GetComponent<Actor>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player" && bullettype == BULLETTYPE.ENEMY)
        {
            collision.gameObject.GetComponent<PlayerActor>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }

        //보스몬스터전용
        /*if (collision.gameObject.tag == "BossEnemy" && bullettype == BULLETTYPE.PLAYER)
        {
            collision.gameObject.GetComponent<Actor>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player" && bullettype == BULLETTYPE.BOSSENEMY)
        {
            collision.gameObject.GetComponent<PlayerActor>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }*/

    }

}

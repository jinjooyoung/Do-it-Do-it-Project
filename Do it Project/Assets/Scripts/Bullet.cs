using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BULLETTYPE
    {
        PLAYER,
        ENEMY
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
            collision.gameObject.GetComponent<Actor>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
        
    }

}
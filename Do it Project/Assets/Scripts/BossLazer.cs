using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLazer : MonoBehaviour
{
    public float rotateSpeed = 0.1f;
    int Damage = 1;

    void Update()
    {
        transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<PlayerActor>().TakeDamage(Damage);
         
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public int Hp = 150;

    private void Update()
    {
        if (Hp <= 0) Die();
    }
    public void Die()
    {
        gameObject.SetActive(false);
        //Object.Destroy( this );
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    void Start()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Monster")
        {
            MonsterController monsterController = other.GetComponent<MonsterController>();

            if (monsterController != null)
            {
                monsterController.Hp -= 10;
                Debug.Log("피가 달았음");
                

            }
        }

       Destroy(gameObject);
    }
}

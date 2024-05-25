using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int HealthPoint;
    public Animator playeranimator;
    public Animator monsteranimator;
    public GameObject slaimPf;
    public GameObject mousePf;
    public GameObject dogPf;
    private void Start()
    {
        playeranimator = GetComponent<Animator>();
        monsteranimator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if(amount > 0)
        {
            HealthPoint -= amount;
            if (gameObject.tag == "Player")
            {
                playeranimator.SetTrigger("Hurt");
            }
            if (gameObject.tag == "Enemy")
            {
                if (slaimPf != null) monsteranimator.SetTrigger("Hurt");
                if (mousePf != null) monsteranimator.SetTrigger("Hurt");
                if (dogPf != null) monsteranimator.SetTrigger("Hurt");
            }
         
            if (HealthPoint < 0)
            {
                SendMessage("Die");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    public int HealthPoint;
    public Animator playeranimator;
    public GameObject UI;
    void Start()
    {
        playeranimator = GetComponent<Animator>();
    }
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        if (amount > 0)
        {
            HealthPoint -= amount;
            playeranimator.SetTrigger("Hurt");
            if (UI != null)
            {
                UI.gameObject.GetComponent<UIManager>().actorHp = HealthPoint;
                UI.gameObject.GetComponent<UIManager>().Hurt();
            }
        }
        if (HealthPoint == 0)
        {
            UI.gameObject.GetComponent<UIManager>().GameOver();
        }
    }
}
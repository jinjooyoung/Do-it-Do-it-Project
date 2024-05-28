using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int HealthPoint;
    public Animator monsteranimator;
    public GameObject slaimPf;
    public GameObject mousePf;
    public GameObject dogPf;
    //»ç¿îµå
    public GameObject slaimDied;
    public GameObject mouseDied;
    public GameObject dogDied;
    public GameObject rockDied;
    public GameObject dogCome;
    private void Start()
    {
        monsteranimator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if(amount > 0)
        {
            HealthPoint -= amount;
            if (slaimPf != null) monsteranimator.SetTrigger("Hurt");
            if (mousePf != null) monsteranimator.SetTrigger("Hurt");
            if (dogPf != null) monsteranimator.SetTrigger("Hurt");
            if(dogPf != null) dogCome.GetComponent<AudioSource>().Play();

        }
        if (HealthPoint < 0)
        {
            if(slaimPf != null) slaimDied.GetComponent<AudioSource>().Play();
            else if(mousePf != null) mouseDied.GetComponent <AudioSource>().Play();
            else if(dogPf != null) dogDied.GetComponent<AudioSource>().Play();
            else if(rockDied != null) rockDied.GetComponent<AudioSource>().Play();
            SendMessage("Die");
        }
    }
}


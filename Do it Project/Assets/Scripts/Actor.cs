using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int HealthPoint;
   
    public void TakeDamage(int amount)
    {
        if(amount > 0)
        {
            HealthPoint -= amount;
            if(HealthPoint < 0)
            {
                SendMessage("Die");
            }
        }
    }
}

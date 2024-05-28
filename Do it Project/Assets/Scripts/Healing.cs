using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private GameObject heal;
    //AudioSource sound;
    bool issound = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (issound == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                heal.GetComponent<AudioSource>().Play();
                issound = true;
            }
        }
    }
}

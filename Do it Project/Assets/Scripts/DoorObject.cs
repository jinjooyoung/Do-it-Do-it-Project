using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorObject : MonoBehaviour
{
    public int DoorBlockIndex = 1;
    public int MoveToIndex = 1;
    AudioSource sound;
    public GameObject gameObject;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sound = gameObject.GetComponent<AudioSource>();
            sound.Play();

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Right : MonoBehaviour
{
    public Transform exitDoor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")  //부딪힌 오브젝트의 태그가 플레이어일 때
        {
            other.transform.position = exitDoor.position + new Vector3 (1.5f, 0, 0);
        }
    }
}

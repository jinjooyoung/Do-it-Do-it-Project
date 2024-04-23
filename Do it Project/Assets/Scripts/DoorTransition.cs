using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
    public int direction;   // 0 合率, 1 悼率, 2 巢率, 3 辑率    
    //public Transform exitDoor;
    public Transform mainCamTransform;

    public float offSetNSCharater = 1.5f;
    public float offSetNSCamera = 10f;
    public float offSetEWCharater = 2.53f;
    public float offSetEWCamera = 20f;

    void Start()
    {
        mainCamTransform = FindObjectOfType<Camera>().transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")  //何碟腮 坷宏璃飘狼 怕弊啊 敲饭捞绢老 锭
        {

            Debug.Log("面倒 车蝶!~");
            if (direction == 0)
            {
                Debug.Log("合率 车蝶!~");
                other.transform.position += new Vector3(0, offSetNSCharater, 0);
                mainCamTransform.position += new Vector3(0f, offSetNSCamera, 0f);
            }
            else if (direction == 2)
            {
                other.transform.position += new Vector3(0, -offSetNSCharater, 0);
                mainCamTransform.position += new Vector3(0f, -offSetNSCamera, 0f);
            }
            else if (direction == 1)
            {
                Debug.Log("悼率 车蝶!~");
                other.transform.position += new Vector3(offSetEWCharater, 0f, 0);
                mainCamTransform.position += new Vector3(offSetEWCamera, 0f, 0f);
            }
            else if (direction == 3)
            {
                Debug.Log("辑率 车蝶!~");
                other.transform.position += new Vector3(-offSetEWCharater, 0f, 0f);
                mainCamTransform.position += new Vector3(-offSetEWCamera, 0f, 0f);
            }
        }
    }
}

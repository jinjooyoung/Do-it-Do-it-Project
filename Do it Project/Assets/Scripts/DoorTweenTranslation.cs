using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class DoorTweenTranslation : MonoBehaviour
{
    //public int direction;   // 0 북쪽, 1 동쪽, 2 남쪽, 3 서쪽    
    //public Transform exitDoor;
    public Transform mainCamTransform;
    public int roomNumber;
    private Vector3 mapPos;
    private float duration = 0.3f;
    public bool left;
    public bool right;
    //public Ease ease;

    public float offSetNSCharater = 1.5f;       // 위아래 캐릭터 이동 거리    
    public float offSetNSCamera = 15f;          // 위아래 카메라 이동 거리
    public float offSetEWCharater = 2.6f;      // 좌우 캐릭터 이동 거리 
    public float offSetEWCamera = 20f;          // 좌우 카메라 이동 거리
    //public float cameraPosition;

    void Start()
    {
        mainCamTransform = FindObjectOfType<Camera>().transform;
        //cameraPosition = Camera.transform.
        left = false;
        right = false;

        if (left == true)
        {
            int lr = -1;
        }
        else if(left != true)
        {
            Debug.Log("체크안됨");
        }

        if (right == true)
        {
            int lr = 1;
        }
        else if (left != true)
        {
            Debug.Log("체크안됨");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (roomNumber == 0)
            {
                Vector3 mapPos = new Vector3(-3, 0, 0);
                other.transform.position += mapPos + new Vector3(); //아 모르겠다 이러면 비효율적이잖아 결국 똑같잖아
                mainCamTransform.DOMove(mapPos * offSetEWCamera, duration, false);
            }
            else if (roomNumber == 1)
            {
                Vector3 mapPos = new Vector3(-2, 0, 0);
                other.transform.position += new Vector3(0, offSetNSCharater, 0);
                mainCamTransform.DOMove(mapPos * offSetEWCamera, duration, false);
            }
        }

        /*if (other.gameObject.tag == "Player")  //부딪힌 오브젝트의 태그가 플레이어일 때
        {
            if (direction == 0) // 북쪽
            {
                other.transform.position += new Vector3(0, offSetNSCharater, 0);
                mainCamTransform.position += new Vector3(0f, offSetNSCamera, 0f);
            }
            else if (direction == 2)    // 남쪽
            {
                other.transform.position += new Vector3(0, -offSetNSCharater, 0);
                mainCamTransform.position += new Vector3(0f, -offSetNSCamera, 0f);
            }
            else if (direction == 1)    // 동쪽
            {
                other.transform.position += new Vector3(offSetEWCharater, 0f, 0);
                mainCamTransform.position += new Vector3(offSetEWCamera, 0f, 0f);
                //mainCamTransform.DOMoveX(0, duration, false).SetEase(ease);
                //mainCamTransform.DOMoveX(new Vector3(-offSetEWCamera, 0f, 0f), 0.5f).SetEase(ease);
                //mainCamTransform.DOLocalMoveX(offSetEWCamera, 0.5f).SetEase(ease);
            }
            else if (direction == 3)    // 서쪽
            {
                other.transform.position += new Vector3(-offSetEWCharater, 0f, 0f);
                //mainCamTransform.position += new Vector3(-offSetEWCamera, 0f, 0f);                
                //mainCamTransform.DOMoveX(-offSetEWCamera, duration, false);
                mainCamTransform.DOLocalMoveX(-offSetEWCamera, duration).SetEase(Ease.OutExpo);
                


            }
        }*/
    }
}

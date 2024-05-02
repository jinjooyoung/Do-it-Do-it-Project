using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class DoorTransition : MonoBehaviour
{
    public int direction;   // 0 북쪽, 1 동쪽, 2 남쪽, 3 서쪽
    public Transform mainCamTransform;
    private float duration = 0.3f;

    public float offSetNSCharater = 1.5f;       // 위아래 캐릭터 이동 거리    
    public float offSetNSCamera = 10f;          // 위아래 카메라 이동 거리
    public float offSetEWCharater = 2.53f;      // 좌우 캐릭터 이동 거리 
    public float offSetEWCamera = 20f;          // 좌우 카메라 이동 거리
    //public float cameraPosition;

    void Start()
    {
        mainCamTransform = FindObjectOfType<Camera>().transform;        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")  //부딪힌 오브젝트의 태그가 플레이어일 때
        {
            if (direction == 0) // 북쪽
            {
                other.transform.position += new Vector3(0, offSetNSCharater, 0);
                //mainCamTransform.position += new Vector3(0f, offSetNSCamera, 0f);
                mainCamTransform.DOMoveY(mainCamTransform.position.y + offSetNSCamera, 0f, false).SetEase(Ease.OutExpo);
            }
            else if (direction == 2)    // 남쪽
            {
                other.transform.position += new Vector3(0, -offSetNSCharater, 0);
                mainCamTransform.position += new Vector3(0f, -offSetNSCamera, 0f);
            }
            else if (direction == 1)    // 동쪽
            {
                other.transform.position += new Vector3(offSetEWCharater, 0f, 0);
                //mainCamTransform.position += new Vector3(offSetEWCamera, 0f, 0f);
                mainCamTransform.DOMoveX(mainCamTransform.position.x + offSetEWCamera, duration, false).SetEase(Ease.OutExpo);

            }
            else if (direction == 3)    // 서쪽
            {
                other.transform.position += new Vector3(-offSetEWCharater, 0f, 0f);
                //mainCamTransform.position += new Vector3(-offSetEWCamera, 0f, 0f);
                mainCamTransform.DOMoveX(mainCamTransform.position.x - offSetEWCamera, duration, false).SetEase(Ease.OutExpo);
            }
        }
    }
}

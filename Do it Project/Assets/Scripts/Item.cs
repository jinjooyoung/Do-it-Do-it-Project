using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World); //아이템 회전 모션 (기능은 없고 모션만) 따라서 없어도 무관함
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")  //부딪힌 오브젝트의 태그가 플레이어일 때
        {
            playerscript player = other.GetComponent<playerscript>(); //Player의 스크립트 컴포넌트 가져오기
            player.itemCount++; //아이템 카운트 + 1
            print("아이탬이 들어왔습니다.");
            gameObject.SetActive(false); //오브젝트 비활성화
        }

    }
}

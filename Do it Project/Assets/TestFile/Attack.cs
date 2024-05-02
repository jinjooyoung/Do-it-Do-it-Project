using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{

    //트리거 충돌 시 자동으로 실행되는 메서드
    void OnTriggerStay(Collider other)
    {    //충돌한 상대방 게임 오브젝트가 player 태그를 가진 경우
        if (other.tag == "Monster")
        {
            //상대방 게임 오브젝트에서 playerController 컴포넌트 가져오기
            Monster monster = other.GetComponent<Monster>();


            if (monster != null)
            {

                monster.Die();
            }
        }
    }


}

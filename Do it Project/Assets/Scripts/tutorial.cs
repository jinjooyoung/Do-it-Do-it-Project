using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject imageToShow; // 활성화할 이미지

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))   //플레이어 에 객체 태그 확인
        {
            imageToShow.SetActive(true);    //이미지 활성화
        }

        if (other.CompareTag("Player"))    //플레이어 에 객체 태그 확인
        {
            imageToShow.SetActive(false);  //이미지 비활성화
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Image()
    {
        Image.SetActive(false);
    }

}






//처음 시작화면 -> 인게임 으로 들어가고 그 다음 튜토리얼 을 시작하는 방에 적용 하는 스크립트 튜토리얼 방 박스콜라이더 에 적용 

//다음 적용은 스타트 에서 인게임 에서 튜토리얼 이 뜨게 만드는 스크립트 작성 예정


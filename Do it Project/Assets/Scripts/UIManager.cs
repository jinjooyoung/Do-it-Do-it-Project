using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject SettingUI;
    public GameObject TutorialUI;
    bool isTut = false;
    float Timer = 0;
    public GameObject player;
    Rigidbody2D playerRb;
    public GameObject[] UIindex = new GameObject[10];
    public int actorHp;
    public GameObject cloud1;
    public GameObject cloud2;
    //게임클리어씬용
    public GameObject credit1;
    public GameObject credit2;
    public GameObject endPosition1;
    public GameObject endPosition2;
    public GameObject credit;
    float Timer2 = 0;
    bool isPlaying = false;
    bool isPlaying2 = false;
    //게임오버씬용
    public GameObject cloud_1;
    public GameObject cloud_2;
    public GameObject cloud_3;
    //보스용
    public GameObject Boss;
    //사운드
    AudioSource sound;
    [SerializeField] private AudioClip[] clip;

    private void Start()
    {
        sound = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "MainGameScene") //튜토리얼창 키기설정
        {
            sound.clip = clip[1];
            sound.Play();

            isTut = true;
            TutorialUI.SetActive(true);
            playerRb = player.GetComponent<Rigidbody2D>();
            playerRb.simulated = false;
        }
    }
    private void Update()
    {


        if (SceneManager.GetActiveScene().name == "MainGameScene")  // 튜토리얼창 끄기설정
        {

            if (Input.GetKey(KeyCode.Escape))
            {
                Timer += Time.deltaTime;
                playerRb.simulated = true;
                TutorialUI.SetActive(false);
                player.SetActive(true);
                if (Timer >= 0.2f)
                    isTut = false;
                sound.clip = clip[2];
                sound.Play();
            }
            
            if (Input.GetKeyUp(KeyCode.Escape) && isTut == false) //설정창 설정
            {
                sound.clip = clip[1];
                sound.Play();

                SettingUI.SetActive(true);
                playerRb.simulated = false;
            }
        }
        if(SceneManager.GetActiveScene().name == "StartUI")  //시작화면의 구룸애니메이션
        {
            cloud1.transform.DOMoveX(300, 25f);
            cloud2.transform.DOMoveX(1280, 25f);
        }
        if(SceneManager.GetActiveScene().name == "GameClearUI") //그래딧 애니메이션
        {
            credit.SetActive(true);
            isPlaying = true;
            credit1.transform.position = Vector2.MoveTowards(credit1.transform.position, endPosition1.transform.position, 0.71f);
            credit2.transform.position = Vector2.MoveTowards(credit2.transform.position, endPosition2.transform.position, 0.71f);
            if(isPlaying2 == true)
            {
                credit.SetActive(false);
                Timer2 = 0;
                isPlaying = false;

                if(Input.GetKey(KeyCode.Escape))
                    BackToStart();
            }
        }
        if (isPlaying == true)
        {
            Timer2 += Time.deltaTime;
        }
        if (Timer2 >= 43f)
        {
            sound.clip = clip[5];
            sound.Play();

            isPlaying2 = true;
        }
        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            cloud_1.transform.position = Vector2.MoveTowards(cloud_1.transform.position, new Vector2(1000,830), 0.1f);
            cloud_2.transform.position = Vector2.MoveTowards(cloud_2.transform.position, new Vector2(-60,320), 0.1f);
            cloud_3.transform.position = Vector2.MoveTowards(cloud_3.transform.position, new Vector2(1000, 172), 0.1f);
        }
    }
    public void Hurt()  //캐릭터가 피격당할 시, 쳬력이미지 변경
    {
        if(actorHp % 2 == 1)
        {
            for(int i = 14; i >=10; i--)
            {
                if (i == actorHp / 2 + 10)
                {
                    UIindex[i].SetActive(false);
                    UIindex[i - 5].SetActive(true);
                }
            }
        }
        else if (actorHp % 2 == 0 && actorHp != 0)
        {
            for (int j = 9; j >= 6; j--)
            {
                if(j == actorHp / 2 + 5)  
                {
                    UIindex[j].SetActive(false);
                    UIindex[j - 5].SetActive(true);
                }
            }
        }
        if(actorHp == 0 )
        {
            UIindex[5].SetActive(false);
            UIindex[0].SetActive(true);
        }
    }
    public void Heal()
    {
        for(int i =10; i <=14;  i++)
        {
            UIindex[i].SetActive(true);
            UIindex[i - 5].SetActive(false);
            UIindex[i - 10].SetActive(false);
        }
    }

    public void StartGame() //시작씬에서 게임씬으로 이동
    {
        sound.clip = clip[0];//버튼사운드
        sound.Play();
        SceneManager.LoadScene("MainGameScene");

    }
    public void ExitGame() // 시작씬에서 게임나가기
    {
        sound.clip = clip[0];//버튼사운드
        sound.Play();
        Application.Quit();

    }
    public void OptionUI() // 시작씬에서 옵션씬으로 이동
    {
        sound.clip = clip[0];//버튼사운드
        sound.Play();
        //DontDestroyOnLoad(sound);
        SceneManager.LoadScene("OptionUI");


    }
    public void BackToStart() // 설정창에서 시작씬으로 이동
    {
        SceneManager.LoadScene("StartUI");
    }
    public void Continu()  // 설정창 끄기
    {
        if (SceneManager.GetActiveScene().name == "MainGameScene")
        {
            SettingUI.SetActive(false);
            playerRb.simulated = true;
        }
        sound.clip = clip[2];
        sound.Play();
    }
    public void Clear()
    {
        SceneManager.LoadScene("GameClearUI");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void GotoBoss()
    {
        Boss.SetActive(true);
    }

}

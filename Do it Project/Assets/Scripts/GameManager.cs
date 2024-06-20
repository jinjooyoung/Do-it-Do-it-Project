using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] MapBlock = new GameObject[10];
    public CameraController cameraController;
    public int PlayerBlockIndex = 1;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 2번째챕터로 이동
        {
            player.transform.position = MapBlock[40].transform.position + new Vector3(0, 0.5f, 0);
            PlayerBlockIndex = 40;
            MoveBlock(40);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //보스방전으로 이동
        {
            player.transform.position = MapBlock[53].transform.position + new Vector3(0, 0.5f, 0);
            PlayerBlockIndex = 53;
            MoveBlock(53);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //보스방으로 이동
        {
            player.transform.position = MapBlock[54].transform.position + new Vector3(0, 0.5f, 0);
            PlayerBlockIndex = 54;
            MoveBlock(54);
        }
    }

    public void MoveBlock(int BlockNumber)
    {
        cameraController.MoveCamera(MapBlock[BlockNumber].transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] MapBlock = new GameObject[10];
    public CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveBlock(int BlockNumber)
    {
        cameraController.MoveCamera(MapBlock[BlockNumber].transform.position);
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class TweenTest : MonoBehaviour
{
    public Ease ease;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //스페이스바를 누르면
        {
            //transform.DOMoveX(5, 0.5f);
            transform.DOMoveX(5, 0.5f).SetEase(ease);



        }
    }
}
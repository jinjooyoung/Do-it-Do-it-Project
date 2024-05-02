using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Data.SqlTypes;
using Unity.VisualScripting;

public class EnemyMove : MonoBehaviour
{
    public int state;
   
    void Start()
    {
        this.gameObject.transform.DOMove(transform.position + new Vector3(transform.position.x + 20, 0.0f, 0.0f), 1.0f)
            .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
         
    }


    void Update()
    {

    }


}

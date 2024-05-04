using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public void MoveCamera(Vector3 position)
    {
        transform.DOMove(position + new Vector3(0,0,-10), 1.0f);
    }
}

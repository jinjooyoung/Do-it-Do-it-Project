using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public void MoveCamera(Vector3 position)
    {
        transform.DOMove(position, 1.0f);
    }
}

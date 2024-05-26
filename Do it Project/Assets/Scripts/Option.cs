using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    float Timers = 0;
    float TimeRate = 4;
    void Update()
    {
        Timers += Time.deltaTime;
        if (Timers >= TimeRate)
            SceneManager.LoadScene(0);
    }
}

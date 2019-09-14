using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    private void Start()
    {
        BallController.OnMouseDown += DecreaseTime;
        BallController.OnMouseUp += IncreaseTime;
    }

    private void DecreaseTime()
    {
        Time.timeScale = 0.5f;
    }

    void IncreaseTime()
    {
        Time.timeScale = 1f;
    }


}

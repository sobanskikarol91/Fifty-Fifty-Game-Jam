using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    [SerializeField] AudioClip slowSnd;
    [SerializeField] float decreasedTime = 0.3f;

    private void Start()
    {
        BallController.OnMouseDown += DecreaseTime;
        BallController.OnMouseUp += IncreaseTime;
    }

    private void DecreaseTime()
    {
        AudioSource.PlayClipAtPoint(slowSnd, transform.position);
        Time.timeScale = 0.5f;
    }

    void IncreaseTime()
    {
        Time.timeScale = 1f;
    }

    private void OnDisable()
    {
        BallController.OnMouseDown -= DecreaseTime;
        BallController.OnMouseUp -= IncreaseTime;
    }
}

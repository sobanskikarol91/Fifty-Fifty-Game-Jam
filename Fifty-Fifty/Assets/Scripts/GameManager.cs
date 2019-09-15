using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform Player;
    public static GameManager instance;
    public GameObject gameOver;
    private MenuController menu;
    private int totalScore;
    private int timeToChangeColor;
    private int currentPickups;
    public AudioClip piii;

    public void WrongColor()
    {
        Time.timeScale = 1;
        Player.GetComponent<BallController>().Kill();
        Invoke("GameOverPanel", 1.6f);
    }

    public GameObject pusia;
    public GameObject redTip;
    public GameObject blueTip;
    public GameObject greenTip;
    public static HairColor desireColor;
    public static Text scoreTxt;

    private void Awake()
    {
        instance = this;
        ChangeColor();
    }



    internal void GameOver()
    {
        Time.timeScale = 1;
        Invoke("GameOverPanel", 1.6f);
    }

    private void GameOverPanel()
    {
        pusia.SetActive(false);
        gameOver.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void AddScore()
    {
        totalScore += 100;
        CheckIfIsReadyTochangeColor();
        currentPickups++;
        scoreTxt.text = "Score: " + totalScore.ToString();
    }

    private void CheckIfIsReadyTochangeColor()
    {
        if (currentPickups == timeToChangeColor)
            ChangeColor();
    }

    void ChangeColor()
    {
        int colorNr = UnityEngine.Random.Range(0, 3);

        AudioSource.PlayClipAtPoint(piii, Player.transform.position);
        desireColor = (HairColor)colorNr;
        currentPickups = 0;
        pusia.SetActive(true);
        timeToChangeColor = UnityEngine.Random.Range(1, 4);
        DeactivateAllTips();
        if (colorNr == 0) blueTip.SetActive(true);
        else if (colorNr == 1) greenTip.SetActive(true);
        else if (colorNr == 2) redTip.SetActive(true);
    }

    private void DeactivateAllTips()
    {
        blueTip.SetActive(false);
        greenTip.SetActive(false);
        redTip.SetActive(false);
    }
}

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
    private float totalScore;
    private int timeToChangeColor;
    private int currentPickups;
    public AudioClip piii;
    public Text totalScoreTxt;

    public GameObject lighting;

    float decreasionFactor = 40f;

    public void WrongColor()
    {
        scoreTxt.gameObject.SetActive(false);

        Time.timeScale = 1;
        Player.GetComponent<BallController>().Kill();
        Invoke("GameOverPanel", 1.6f);
    }

    public GameObject pusia;
    public GameObject redTip;
    public GameObject blueTip;
    public GameObject greenTip;
    public static HairColor desireColor;
    public Text scoreTxt;

    private void Awake()
    {
        instance = this;

        if (Player == null) return;
        ChangeColor();
    }



    internal void GameOver()
    {
        scoreTxt.gameObject.SetActive(false);
        Time.timeScale = 1;
        Invoke("GameOverPanel", 1.6f);
    }

    internal  void DecreaseTimeSlow()
    {
        totalScore -= Time.deltaTime * decreasionFactor;
        totalScoreTxt.text = "Score: " +  ((int)totalScore).ToString();
        scoreTxt.text = "Score: " +  ((int)totalScore).ToString();
    }

    private void GameOverPanel()
    {
        lighting.SetActive(false);
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
        totalScoreTxt.text = "Score: " + ((int)totalScore).ToString();
        scoreTxt.text = "Score: " + ((int)totalScore).ToString();
        CheckIfIsReadyTochangeColor();
        currentPickups++;

    }

    private void CheckIfIsReadyTochangeColor()
    {
        if (currentPickups == timeToChangeColor)
            ChangeColor();
    }

    void ChangeColor()
    {
        if (Player == null) return;
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

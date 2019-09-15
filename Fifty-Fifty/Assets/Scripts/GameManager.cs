using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform Player;
    public static GameManager instance;
    public GameObject gameOver;
    private MenuController menu;

    private void Awake()
    {
        instance = this;    
    }

    internal void GameOver()
    {
        Invoke("GameOverPanel", 1.6f);
    }

    private void GameOverPanel()
    {
        gameOver.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Game");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        Invoke("Load", 0.2f);
    }

    private void Load()
    {
        SceneManager.LoadScene("Game");
    }

    internal void GameOver()
    {
        throw new NotImplementedException();
    }
}
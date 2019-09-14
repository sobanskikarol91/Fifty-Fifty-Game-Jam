using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Player;
    public static GameManager instance;

    private MenuController menu;

    private void Awake()
    {
        instance = this;    
    }

    internal void GameOver()
    {
        menu.GameOver();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Tiempo de juego")]
    public float minutes;
    [Range(0f, 59f)] public float seconds;

    public static GameManager instanceGameManager;
    public static GameManager Instance { get { return instanceGameManager; } }

    private bool endGame;
    //public PlayerManager actualPlayer;
    private void Awake()
    {
        if (instanceGameManager != null && instanceGameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instanceGameManager = this;
        }
    }
    void Start()
    {
        endGame = false;
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <= 0)
        {
            seconds = 60;
            if (minutes >= 1)
            {
                minutes--;
            }
            else
            {
                endGame = true;
                Pause();
            }
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public float GetTimerMin()
    {
        return minutes;
    }
    public float GetTimerSec()
    {
        return seconds;
    }
}

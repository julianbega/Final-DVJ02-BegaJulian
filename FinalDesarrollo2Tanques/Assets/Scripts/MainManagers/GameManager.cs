using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Tiempo de juego")]
    public float minutes;
    [Range(0f, 59f)] public float seconds;

    private float actualSeconds;
    private float actualMinutes;

    public static GameManager instanceGameManager;
    public static GameManager Instance { get { return instanceGameManager; } }

    private bool endGame;
    private bool isPaused;
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
        actualSeconds = seconds;
        actualMinutes = minutes;
    }

    void Update()
    {
        actualSeconds -= Time.deltaTime;
        if (actualSeconds <= 0)
        {
            actualSeconds = 60;
            if (actualMinutes >= 1)
            {
                actualMinutes--;
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
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    public float GetTimerMin()
    {
        return actualMinutes;
    }
    public float GetTimerSec()
    {
        return actualSeconds;
    }
    public bool GetIsPaused()
    {
        return isPaused;
    }
    public bool GetEndGame()
    {
        return endGame;
    }
    public void SetEndGame(bool state)
    {
        endGame = state;
    }
    public void RestartTime()
    {
        actualSeconds = seconds;
        actualMinutes = minutes;
    }

}

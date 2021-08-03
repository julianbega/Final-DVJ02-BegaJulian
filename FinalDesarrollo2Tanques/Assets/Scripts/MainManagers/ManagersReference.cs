using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagersReference : MonoBehaviour
{
    public GameManager referenceManager;
    public MyScenelManager referenceSceneManager;
    private void Awake()
    {
        referenceManager = null;
        referenceSceneManager = null;
    }
    void Start()
    {
        referenceManager = FindObjectOfType<GameManager>();
        referenceSceneManager = FindObjectOfType<MyScenelManager>();
    }

    void Update()
    {
        if (referenceManager == null)
        {
            referenceManager = FindObjectOfType<GameManager>();
        }
        if (referenceSceneManager == null)
        {
            referenceSceneManager = FindObjectOfType<MyScenelManager>();
        }

    }

    public void PauseGame()
    {
        referenceManager.Pause();
    }

    public void GoToMenu()
    {
        referenceSceneManager.ChangeScene("MainMenu");
    }
    public void GoToGame()
    {
        referenceSceneManager.ChangeScene("Game");
    }
    public void GoToCredits()
    {
        referenceSceneManager.ChangeScene("Credits");
    }
    public void ExitGame()
    {
        referenceSceneManager.OnClickQuit();
    }

}

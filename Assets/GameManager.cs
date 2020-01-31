    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    public SceneFader sceneFader;
    void Start()
    {
        GameIsOver = false;    
    }

    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        
        if (PlayerStats.Lives<=0)
        {
            EndGame();
        }    
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);

    }

    public void WinLevel()
    {
        Debug.Log("LEVEL COMPLETED!!!!!!!!!!!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}

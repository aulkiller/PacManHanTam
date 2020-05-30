using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void Exit ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        PlayerPrefs.SetInt("Highscore", gameStatus.currentScore);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);      
    }

    public void Next()
    {
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.Lanjut();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    //void Awake()
    //{
    //    Time.timeScale = 1;
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.None;
    //}

    [SerializeField]private Text highScore;
    

    private void Start()
    { 
        highScore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }



    public void Mulai()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        highScore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
    
}

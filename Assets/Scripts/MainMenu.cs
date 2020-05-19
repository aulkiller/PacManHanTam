using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //void Awake()
    //{
    //    Time.timeScale = 1;
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.None;
    //}

    public void Mulai()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

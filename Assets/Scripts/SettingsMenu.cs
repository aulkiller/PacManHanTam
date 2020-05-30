using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer volMixer;
    public Slider volSlider;
    public Toggle fullScreenToggle;
    //public GameObject Credits;
    private int screenInt;
    private int resolutionh,resolutionw;
    private int currentResolutionIndex = 0;
   // Resolution[] resolutions;
    private bool isFullScreen = false;
    const string prefname = "optionvalue";
    const string resname = "resolutionoption";

    // Save the values of quality
    void Awake()
    {
        screenInt = PlayerPrefs.GetInt("togglestate");

        if (screenInt == 1)
        {
            isFullScreen = true;
            fullScreenToggle.isOn = true;
        }
        else
        {
            fullScreenToggle.isOn = false;
        }

        //resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index => 
        //{
        //    PlayerPrefs.SetInt(resname, resolutionDropdown.value);
        //    PlayerPrefs.Save();
        //}));
    }
    
    void Start ()
    {
        volSlider.value = PlayerPrefs.GetFloat("MVolume",1f);
        volMixer.SetFloat("volume",PlayerPrefs.GetFloat("MVolume"));


        

        //resolutionDropdown.value = PlayerPrefs.GetInt(resname, currentResolutionIndex);
        
    }
    //public void Resolution800x600(bool active)
    //{
    //    if (active == false)
    //    {
    //        PlayerPrefs.SetInt("togglestate8x6", 0);
    //    }
    //    else
    //    {
    //        Screen.SetResolution(800, 600, Screen.fullScreen);
    //        PlayerPrefs.SetInt("togglestate8x6", 1);
    //    }
    //}
    //public void Resolution1280x720(bool active)
    //{
    //    if (active == false)
    //    {
    //        PlayerPrefs.SetInt("togglestate12x72", 0);
    //    }
    //    else
    //    {
    //        Screen.SetResolution(1280, 720,Screen.fullScreen);
    //        PlayerPrefs.SetInt("togglestate12x72", 1);
    //    }
    //}
    //public void Resolution1366x768(bool active)
    //{
    //    if (active == false)
    //    {
    //        PlayerPrefs.SetInt("togglestate13x76", 0);
    //    }
    //    else
    //    {
    //        Screen.SetResolution(1366, 768,Screen.fullScreen);
    //        PlayerPrefs.SetInt("togglestate12x76", 1);
    //    }
    //}

    //public void SetResolution(int resolutionIndex)
    //{
    //    currentResolutionIndex = resolutionIndex;

    //    switch(currentResolutionIndex)
    //    {
    //    case 0:
    //        resolutionw = 800;
    //        resolutionh = 600;
    //        break;
    //    case 1:
    //        resolutionw = 1280;
    //        resolutionh = 720;
    //        break;
    //    case 2:
    //        resolutionw = 1366;
    //        resolutionh = 768;
    //        break;
    //    case 3:
    //        resolutionw = 1920;
    //        resolutionh = 1080;
    //        break;
    //    }

    //    Screen.SetResolution(resolutionw, resolutionh, Screen.fullScreen);
    //}

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("MVolume",volume);
        volMixer.SetFloat("volume",PlayerPrefs.GetFloat("MVolume"));
    }



    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if (isFullScreen == false)
        {
            Screen.SetResolution(640, 360, false);
            PlayerPrefs.SetInt("togglestate", 0);
        }
        else
        {
            isFullScreen = true;
            Screen.SetResolution(1408, 792, true);
            PlayerPrefs.SetInt("togglestate", 1);
        }
    }
    public void Reset()
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }

}



































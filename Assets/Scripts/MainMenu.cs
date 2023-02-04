using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene("JakeScene");    
    }

    public void QuitGame()
    {
        Debug.Log("The Prod Game will close!");
        Application.Quit();
    }


    //OPTIONS MENU
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetGraphics (int graphicsIndex)
    {
        QualitySettings.SetQualityLevel(graphicsIndex);
    }
}

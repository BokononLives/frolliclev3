using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

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



}

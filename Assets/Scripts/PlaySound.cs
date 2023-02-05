using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource ButtonClick1;
    public AudioSource ButtonClick2;
    public AudioSource ButtonClick3;
    public AudioSource ButtonClick4;
    public AudioSource Click;

    public void playButtonClick1()
    {
        ButtonClick1.Play();
    }

    public void playButtonClick2()
    {
        ButtonClick2.Play();
    }

    public void playButtonClick3()
    {
        ButtonClick3.Play();
    }

    public void playButtonClick4()
    {
        ButtonClick4.Play();
    }

    public void playSliderClick()
    {
        Click.Play();
    }

}

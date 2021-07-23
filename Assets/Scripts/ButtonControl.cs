using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{

    public AudioSource ButtonClick;
    public void StartButton()
    {
        ButtonClick.Play();
        SceneManager.LoadScene(10);
    }
    public void QuiteButton()
    {
        ButtonClick.Play();
        Application.Quit();
    }

}

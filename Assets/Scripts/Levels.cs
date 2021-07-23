using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public AudioSource ButtonMusic;
    void Start()
    {
        int ButtonActive = PlayerPrefs.GetInt("LevelCompleted");
        for (int i = 0; i <= ButtonActive; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void OpenLevel(int number)
    {
        ButtonMusic.Play();
        SceneManager.LoadScene(number);
    }

    public void CrossButton()
    {
        ButtonMusic.Play();
        SceneManager.LoadScene(0);
    }

}

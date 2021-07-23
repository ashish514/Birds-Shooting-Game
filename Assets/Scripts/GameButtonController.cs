using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameButtonController : MonoBehaviour
{
    public AudioSource ButtonClickMusic;
    public GameObject PauseMenu;
    private Gun gun;
    public GameObject PausedImageButton;
    void Start()
    {
        gun = FindObjectOfType<Gun>();
    }

    void Update()
    {

        if (gun.WinMenu.activeSelf == true || gun.LossMenu.activeSelf == true)
        {
            PausedImageButton.SetActive(false);
        }
        else if (gun.WinMenu.activeSelf == false || gun.LossMenu.activeSelf == false)
        {
            PausedImageButton.SetActive(true);
        }
        

    }

    public void PauseButton()
    {
        ButtonClickMusic.Play();
        PausedImageButton.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        ButtonClickMusic.Play();
        StartCoroutine(countdownTimer());
        PausedImageButton.SetActive(true);
        PauseMenu.SetActive(false);
    }
    public void RetryButton()
    {
        ButtonClickMusic.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void QuiteButton()
    {
        ButtonClickMusic.Play();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }


    public void RestartGame()
    {
        ButtonClickMusic.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        ButtonClickMusic.Play();
        int CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentLevel+1);

    }

    public void HomeMenu()
    {
        ButtonClickMusic.Play();
        SceneManager.LoadScene(0);
    }

    IEnumerator countdownTimer()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 1;
    }

}

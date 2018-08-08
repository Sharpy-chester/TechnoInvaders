using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool paused = false;
    public GameObject dark;

    public void Play()
    {
        SceneManager.LoadScene("mainScene");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        if (paused)
        {
            Resume();

        }
        else
        {
            Pause();
        }
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
    void Resume()
    {
        dark.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        dark.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

}

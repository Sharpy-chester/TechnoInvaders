using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScoreManager : MonoBehaviour
{

    ScoreManager scoreManager;
    GameObject scoreManagerObj;
    float score;
    int level;

    public Text scoreTxt;
    public Text LevelTxt;

    public Button menu;
    public Button quit;

    void Start()
    {
        Time.timeScale = 1f;
        scoreManagerObj = GameObject.Find("ScoreManager");
        scoreManager = scoreManagerObj.GetComponent<ScoreManager>();
        score = scoreManager.score;
        level = scoreManager.level;
        Destroy(scoreManagerObj);
        scoreTxt.text = ("Score: " + score);
        LevelTxt.text = ("Level: " + level);

    }


    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("mainScene");
    }
}

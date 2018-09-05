using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    // MainController mainController;
    public GameObject controller;
    public float score;
    public int level;

    void Start()
    {
        
    }


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // mainController = controller.GetComponent<MainController>();
    }

    public void Score(float finalScore, int finalLevel)
    {
        score = finalScore;
        level = finalLevel;
    }
}

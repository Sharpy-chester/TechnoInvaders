using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    MainController mainController;
    public GameObject gameManager;
    public GameObject player;
    SpriteRenderer playerSprite;
    public Text creditsTxt;


    void Start()
    {
        mainController = gameManager.GetComponent<MainController>();
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    void Awake()
    {

    }

    void Update()
    {


    }


    public void RedShip()
    {
        if (mainController.credits >= 10)
        {
            mainController.credits -= 10;
            creditsTxt.text = "Credits: " + mainController.credits;
            playerSprite.color = new Color(125, 255, 255);
        }



    }

    public void Exit()
    {

        this.gameObject.SetActive(false);
    }
}

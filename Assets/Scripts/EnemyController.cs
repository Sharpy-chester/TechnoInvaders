using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public float hp = 5;
    float maxhp = 5;
    MainController mainController;
    public Image healthBar;

    void Start ()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        mainController = gameManager.GetComponent<MainController>();


        maxhp = mainController.hp;
        hp = mainController.hp;
    }

    void Update () {

        float hpBar = hp / maxhp;
        healthBar.rectTransform.localScale = new Vector3(hpBar, 1, 1);

        if (hp <= 0)
        {
            
            Destroy(this.gameObject);
        }
        if (mainController.currentY == this.transform.position.y)
        {
            //add shooting function
        }
	}
}

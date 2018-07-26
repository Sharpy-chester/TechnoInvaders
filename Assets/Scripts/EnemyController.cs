using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public float hp = 5;
    float maxhp = 5;
    AlienSpawn alienSpawn;
    public Image healthBar;

    void Start ()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        alienSpawn = gameManager.GetComponent<AlienSpawn>();


        maxhp = alienSpawn.hp;
        hp = alienSpawn.hp;
    }

    void Update () {

        float hpBar = hp / maxhp;
        healthBar.rectTransform.localScale = new Vector3(hpBar, 1, 1);

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

	}
}

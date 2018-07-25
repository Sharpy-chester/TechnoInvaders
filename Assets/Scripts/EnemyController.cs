using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public float hp = 5;
    float maxHp = 5;
    AlienSpawn alienSpawn;
    public Image healthBar;

    void Awake ()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        alienSpawn = gameManager.GetComponent<AlienSpawn>();
        if (alienSpawn.level > 0 && alienSpawn.level < 10)
        {
            hp = 5;
            maxHp = 5;
        }
        else if (alienSpawn.level > 9 && alienSpawn.level < 20)
        {
            hp = 10;
            maxHp = 10;
        }
        else if (alienSpawn.level > 19 && alienSpawn.level < 30)
        {
            hp = 15;
            maxHp = 15;
        }
        else
        {
            hp = 20;
            maxHp = 20;
        }
    }

    void Update () {

        float hpBar = hp / maxHp;
        healthBar.rectTransform.localScale = new Vector3(hpBar, 1, 1);

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

	}
}

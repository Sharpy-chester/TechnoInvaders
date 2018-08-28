﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 1f;
    EnemyController enemyController;
    Ctrl ctrl;
    BossController bossController;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        ctrl = player.GetComponent<Ctrl>();

    }

    void Update()
    {

        this.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        Destroy(this.gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Invader(Clone)")
        {
            enemyController = collision.gameObject.GetComponent<EnemyController>();
            float hp = enemyController.hp;
            hp = hp - 5;
            enemyController.hp = hp;
            Destroy(this.gameObject);
        }
        else if (collision.name == "EnemyHP")
        {
            enemyController = collision.gameObject.GetComponent<EnemyController>();
            float hp = enemyController.hp;
            hp -= 5;
            enemyController.hp = hp;
            if (ctrl.hp != ctrl.maxHp)
            {
                ctrl.hp += 5;
            }

            Destroy(this.gameObject);
        }
        else if (collision.name == "Boss_Placeholder(Clone)")
        {
            bossController = collision.GetComponent<BossController>();
            bossController.hp -= 5;
            Destroy(this.gameObject);
        }


    }
}

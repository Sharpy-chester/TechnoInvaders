using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    public float speed = 1000f;
    EnemyController enemyController;

    void Start()
    {


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
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            float hp = enemyController.hp;
            hp = hp - 15;
            enemyController.hp = hp;
            Destroy(this.gameObject);
        }


    }
}

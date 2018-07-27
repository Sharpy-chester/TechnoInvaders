using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 1f;
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
        if (collision.name != "Shot 1(Clone)")
        {
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            float hp = enemyController.hp;
            hp = hp - 5;
            enemyController.hp = hp;
            Destroy(this.gameObject);
        }
        

    }
}

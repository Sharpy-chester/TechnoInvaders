using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 1f;
    EnemyController enemyController;
    Ctrl ctrl;
    BossController bossController;
    public GameObject hitParticleSystem;

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
            // GameObject particle = Instantiate(hitParticleSystem, this.transform);
            // particle.transform.parent = null;
            enemyController = collision.gameObject.GetComponent<EnemyController>();
            float hp = enemyController.hp;
            hp = hp - 5;
            enemyController.hp = hp;
            Destroy(this.gameObject);
        }
        else if (collision.name == "EnemyHP") //This is fine for now but if I add more enemy types I should optimise this
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
            GameObject particle = Instantiate(hitParticleSystem, this.transform);
            particle.transform.parent = null;
            bossController = collision.GetComponent<BossController>();
            bossController.hp -= 5;
            Destroy(this.gameObject);
        }


    }
}

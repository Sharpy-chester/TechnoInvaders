using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{

    public float speed = 1f;

    void Start()
    {

    }

    void Update()
    {
        this.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));

        Destroy(this.gameObject, 5f);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Shot(Clone)")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }
}

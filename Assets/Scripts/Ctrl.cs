using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{

    public float speed = .02f;
    public float timer;
    public float shotDelay = 1f;
    public GameObject shotPrefab;


    void FixedUpdate()
    {
        Movement();
        Shooting();

    }

    void Movement()
    {
        float isMoving = Input.GetAxis("Horizontal");
        if (this.transform.position.x < -2.45 && isMoving < 0)
        {
            isMoving = 0;
        }
        else if (this.transform.position.x > 2.45 && isMoving > 0)
        {
            isMoving = 0;
        }
        this.transform.position += Vector3.right * isMoving * speed;
    }

    void Shooting()
    {
        timer += Time.deltaTime;
        if (timer > shotDelay)
        {
            Instantiate(shotPrefab, this.transform.position, this.transform.rotation);
            timer = 0f;
        }
    }

}

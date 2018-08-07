using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ctrl : MonoBehaviour
{

    public float speed = .02f;
    public float timer;
    public float shotDelay = 1f;
    public GameObject shotPrefab;
    public GameObject controller;
    MainController mainController;
    public Image hpImage;
    public float hp = 100f;
    public float maxHp = 100f;
    float hpBar;

    void Start()
    {
        mainController = controller.GetComponent<MainController>();
        hp = maxHp;
    }
    void FixedUpdate()
    {
        Movement();
        Shooting();
        Health();
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

    void Health()
    {
        hpBar = hp / maxHp;
        hpImage.rectTransform.localScale = new Vector3(hpBar, 1, 1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Shot 1(Clone)")
        {
            hp -= 5f;
            Destroy(collision.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour
{

    public float speed = 0.1f;
    float bounds = 2.76f;
    public bool right = true;
    public float down = 1f;
    public bool horizontal = true;
    public float maxWait = 1f;
    public float wait = 0f;
    public GameObject enemy;
    public int amount = 5;
    float spawnAtX = 0f;
    public Vector3 spawnat;
    float leftEdgeX;
    Vector3 leftEdgeVector;
    float rightEdgeX;
    Vector3 rightEdgeVector;
    GameObject leftEdge;
    GameObject rightEdge;
    public GameObject leftEdgeGO;
    public GameObject rightEdgeGO;
    public float offset = 1.88f;
    public bool test = false;
    public List<GameObject> enemiesInRow;
    GameObject controller;
    MainController mainController;
    int addat = 0;

    void Start()
    {
        controller = GameObject.Find("GameManager");
        mainController = controller.GetComponent<MainController>();
        for (int i = 0; i < amount; i++)
        {
            spawnat = new Vector3(spawnAtX, this.transform.position.y, this.transform.position.z);
            GameObject enemyObj = Instantiate(enemy, spawnat, this.transform.rotation, this.transform);

            mainController.col[i].Add(enemyObj);

            spawnAtX = spawnAtX - 0.88f;


        }


        leftEdgeX = (((float)amount * -0.88f) - 0.4f) + 0.88f;
        leftEdgeVector = new Vector3(leftEdgeX, this.transform.position.y, this.transform.position.z);
        leftEdge = Instantiate(leftEdgeGO, leftEdgeVector, this.transform.rotation, this.transform);
        rightEdgeX = this.transform.transform.position.x + 0.4f; //half of an enemy is approx 0.4 on the x (within margin of error)
        rightEdgeVector = new Vector3(rightEdgeX, this.transform.position.y, this.transform.position.z);
        rightEdge = Instantiate(rightEdgeGO, rightEdgeVector, this.transform.rotation, this.transform);



        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.tag == "Enemy")
            {
                enemiesInRow.Add(transform.GetChild(i).gameObject);
            }
        }
        offset = (float)amount * 0.38f;
        this.transform.position = new Vector3(this.transform.position.x + offset, this.transform.position.y, this.transform.position.z);






    }

    void Update()
    {
        wait += Time.deltaTime;
        Movement();
        if (this.transform.childCount == 0)
        {

        }

        for (int i = 0; i < enemiesInRow.Count; i++)
        {
            if (enemiesInRow[i] == null)
            {
                enemiesInRow.Remove(enemiesInRow[i]);
            }
        }
        if (enemiesInRow.Count == 0)
        {


            mainController.currentY = 10f;
            Destroy(this.gameObject);
            spawnAtX = 0f;
        }


    }



    void Movement()
    {
        if (leftEdge.transform.position.x < -bounds)
        {
            if (test == false)
            {
                horizontal = false;

            }


        }
        else if (rightEdge.transform.position.x > bounds)
        {
            if (test == false)
            {
                horizontal = false;

            }

        }
        if (wait > maxWait)
        {
            test = false;
        }
        if (horizontal)
        {
            if (right && wait > maxWait)
            {

                this.transform.position = new Vector3(this.transform.position.x + 0.25f, this.transform.position.y, this.transform.position.z);
                wait = 0f;

            }

            else if (wait > maxWait)
            {
                this.transform.position = new Vector3(this.transform.position.x - 0.25f, this.transform.position.y, this.transform.position.z);
                wait = 0f;
            }
        }
        else
        {
            if (wait > maxWait)
            {
                this.transform.Translate(new Vector3(0, -1, 0));
                wait = 0f;
                right = !right;
                horizontal = true;
                test = true;
            }
        }
    }
}

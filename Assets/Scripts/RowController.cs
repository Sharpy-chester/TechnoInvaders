using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour
{

    public float speed = 0.1f;
    float bounds = 2.8f;
    public bool right = true;
    public float down = 1f;
    public bool horizontal = true;
    public float maxWait = 1f;
    public float wait = 0f;
    public GameObject enemy;
    public int amount = 5;
    public float spawnAtX = 0f;
    public Vector3 spawnat;
    float leftEdge;
    Vector3 leftEdgeVector;
    float rightEdge;
    Vector3 rightEdgeVector;
    GameObject leftEdgeGO;
    GameObject rightEdgeGO;
    public float offset = 1.88f;
    public bool test = false;

    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            spawnat = new Vector3(spawnAtX, this.transform.position.y, this.transform.position.z);
            spawnAtX = spawnAtX - 0.88f;
            GameObject enemyObj = Instantiate(enemy, spawnat, this.transform.rotation);
            enemyObj.transform.parent = this.transform;
        }
        spawnAtX = 0f;
        spawnat = new Vector3(spawnAtX, this.transform.position.y, this.transform.position.z);
        leftEdge = (((float)amount * -0.88f) - 0.4f) + 0.88f;
        leftEdgeVector = new Vector3(leftEdge, this.transform.position.y, this.transform.position.z);
        leftEdgeGO = Instantiate(new GameObject("LeftEdge"), leftEdgeVector, this.transform.rotation);
        leftEdgeGO.transform.parent = this.transform;
        rightEdge = this.transform.transform.position.x + 0.4f; //half of an enemy is approx 0.4 on the x (within margin of error)
        rightEdgeVector = new Vector3(rightEdge, this.transform.position.y, this.transform.position.z);
        rightEdgeGO = Instantiate(new GameObject("RightEdge"), rightEdgeVector, this.transform.rotation);
        rightEdgeGO.transform.parent = this.transform;
        offset = (float)amount * 0.38f;
        this.transform.position = new Vector3(this.transform.position.x + offset, this.transform.position.y, this.transform.position.z);
    }

    void FixedUpdate()
    {

    }

    void Update()
    {
        wait += Time.deltaTime;
        Movement();
        if (this.transform.childCount == 0)
        {
            GameObject controller = GameObject.Find("GameManager");
            MainController mainController = controller.GetComponent<MainController>();
            mainController.currentY = 10f;
            Destroy(this.gameObject);
        }

        //for(int i = 0; i < transform.childCount; i++)  if i need it later, this can be used for getting each 
        //{                                              of the enemies transforms in the row
        //    enemiesInRow[i] = transform.GetChild(i); 
        //}

    }

    void Movement()
    {
        if (leftEdgeGO.transform.position.x < -bounds)
        {
            if (test == false)
            {
                horizontal = false;

            }

        }
        else if (rightEdgeGO.transform.position.x > bounds)
        {
            if (test == false)
            {
                horizontal = false;

            }

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
    //     if (horizontal)
    //     {
    //         if (right)
    //         {
    //             this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    //             if (this.transform.position.x > bounds)
    //             {

    //                 right = false;
    //                 horizontal = false;
    //                 StartCoroutine(Horizontal(horizontal));
    //             }
    //         }
    //         else
    //         {
    //             this.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    //             if (this.transform.position.x < -bounds)
    //             {

    //                 right = true;
    //                 horizontal = false;
    //                 StartCoroutine(Horizontal(horizontal));
    //             }
    //         }
    //     }
    //     else
    //     {


    //     }



    // }
    // IEnumerator Horizontal(bool horizontal)
    // {
    //     Vector3 moveTo = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
    //     float duration = 0.5f;
    //     for (float t = 0f; t < duration; t += Time.deltaTime)
    //     {
    //         this.transform.position = Vector3.Lerp(this.transform.position, moveTo, t / duration);
    //     }
    //     horizontal = true;


    //     yield return horizontal;
    // }

}

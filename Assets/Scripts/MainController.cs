using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{

    public int amount = 4;
    Vector3 spawnPos = new Vector3(-0.88f, 3, 0);
    GameObject[] rows;
    public GameObject InvaderRow;
    Quaternion rowRot;
    public Text lvlText;
    public int level = 1;
    float wait = 0;
    public float hp = 5f;
    public float currentY = 10;

    void Start()
    {
        rowRot = InvaderRow.transform.rotation;
        hp = 5f;
    }


    void Update()
    {

        rows = GameObject.FindGameObjectsWithTag("Row");
        if (rows.Length == 0)
        {

            spawnPos.y = 3;
            Spawn();
            lvlText.text = ("Level: " + level.ToString());
            currentY = 10;
        }
        else
        {
            foreach (GameObject row in rows)
            {
                
                if (row.transform.position.y < currentY)
                {
                    currentY = row.transform.position.y;
                    //need to get actual gameobject
                    //in the actual space invaders it gets the furthest one down per vertical row. Will need to change this
                }
            }
        }

        print(currentY);




    }

    void Spawn()
    {
        wait += Time.deltaTime;
        if (wait > 3)
        {
            level++;
            for (int i = 0; i < amount; i++)
            {
                Instantiate(InvaderRow, spawnPos, rowRot);
                spawnPos.y -= 1;

            }
            wait = 0f;

            if ((level % 10) == 0 && level < 41)
            {
                hp += 5f;
            }
        }

    }





}

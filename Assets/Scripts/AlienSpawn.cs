using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienSpawn : MonoBehaviour
{

    public int amount = 3;
    Vector3 spawnPos = new Vector3(-0.88f, 2, 0);
    GameObject[] rows;
    public GameObject InvaderRow;
    Quaternion rowRot;
    public Text lvlText;
    int level = 1;
    float wait = 0;

    void Start()
    {
        rowRot = InvaderRow.transform.rotation;
    }


    void Update()
    {

        rows = GameObject.FindGameObjectsWithTag("Row");
        if (rows.Length == 0)
        {
            
            spawnPos.y = 2;
            Spawn();
            lvlText.text = ("Level: " + level.ToString());
        }

    }

    void Spawn()
    {
        wait += Time.deltaTime;
        if (wait > 3)
        {
            level++;
            for (int i = 0; i < amount; i++)
            {
                GameObject row = Instantiate(InvaderRow, spawnPos, rowRot);
                spawnPos.y -= 1;
                
            }
            wait = 0f;
        }
        
        
        
    }



}

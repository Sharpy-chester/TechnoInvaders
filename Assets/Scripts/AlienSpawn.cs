using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawn : MonoBehaviour
{

    public int amount = 3;
    Vector3 spawnPos = new Vector3(-0.88f, 2, 0);
    GameObject[] rows;
    public GameObject InvaderRow;
    

    void Start()
    {
        
    }


    void Update()
    {
        rows = GameObject.FindGameObjectsWithTag("Row");
        if (rows.Length == 0)
        {
            Spawn();
        }

    }

    void Spawn()
    {
        Quaternion rowRot = InvaderRow.transform.rotation;
        GameObject row = Instantiate(InvaderRow, spawnPos, rowRot);
    }



}

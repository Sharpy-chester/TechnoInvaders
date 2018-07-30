using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
    public GameObject[] enemies;
    public List<GameObject> col1;
    public List<GameObject> col2;
    public List<GameObject> col3;
    public List<GameObject> col4;

    public GameObject best1;
    public GameObject best2;
    public GameObject best3;
    public GameObject best4;


    void Start()
    {
        rowRot = InvaderRow.transform.rotation;
        hp = 5f;
        best1.transform.position = new Vector3(0, 10, 0);
        best2.transform.position = new Vector3(0, 10, 0);
        best3.transform.position = new Vector3(0, 10, 0);
        best4.transform.position = new Vector3(0, 10, 0);
    }

    void Update()
    {

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
                }
            }
        }
        if (best1 == null)
        {
            best1 = GameObject.Find("Dummy");
        }
        if (best2 == null)
        {
            best2 = GameObject.Find("Dummy");
        }
        if (best3 == null)
        {
            best3 = GameObject.Find("Dummy");
        }
        if (best4 == null)
        {
            best4 = GameObject.Find("Dummy");
        }
        ColumnManager();
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
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject a in enemies)
        {
            if (a.transform.localPosition.x == -1.5f)
            {
                col1.Add(a);
            }
            if (a.transform.localPosition.x == -.5f)
            {
                col2.Add(a);
            }
            if (a.transform.localPosition.x == .5f)
            {
                col3.Add(a);
            }
            if (a.transform.localPosition.x == 1.5f)
            {
                col4.Add(a);
            }
        }
    }
    void ColumnManager()
    {

        for (int i = 0; i < col1.Count; i++)
        {
            if (col1[i] == null)
            {
                col1.Remove(col1[i]);
            }
            else if (col1[i].transform.position.y < best1.transform.position.y)
            {
                best1 = col1[i];
            }
        }
        for (int i = 0; i < col2.Count; i++)
        {
            if (col2[i] == null)
            {
                col2.Remove(col2[i]);
            }
            else if (col2[i].transform.position.y < best2.transform.position.y)
            {
                best2 = col2[i];
            }
        }
        for (int i = 0; i < col3.Count; i++)
        {
            if (col3[i] == null)
            {
                col3.Remove(col3[i]);
            }
            else if (col3[i].transform.position.y < best3.transform.position.y)
            {
                best3 = col3[i];
            }
        }
        for (int i = 0; i < col4.Count; i++)
        {
            if (col4[i] == null)
            {
                col4.Remove(col4[i]);
            }
            else if (col4[i].transform.position.y < best4.transform.position.y)
            {
                best4 = col4[i];
            }
        }
    }
}
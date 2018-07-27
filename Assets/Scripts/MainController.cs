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

    void Start()
    {
        rowRot = InvaderRow.transform.rotation;
        hp = 5f;
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
        foreach (GameObject i in col1)
        {
            if (i == null)
            {
                col1.Remove(i);
            }
        }
        foreach (GameObject i in col2)
        {
            if (i == null)
            {
                col2.Remove(i);
            }
        }
        foreach (GameObject i in col3)
        {
            if (i == null)
            {
                col3.Remove(i);
            }
        }
        foreach (GameObject i in col4)
        {
            if (i == null)
            {
                col4.Remove(i);
            }
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MainController : MonoBehaviour
{

    public int amount = 4;
    Vector3 spawnPos = new Vector3(0, 3, 0);
    GameObject[] rows;
    public GameObject InvaderRow;
    Quaternion rowRot;
    public Text lvlText;
    public int level = 1;
    float wait = 0;
    public float hp = 5f;
    public float currentY = 10;
    public GameObject[] enemies;
    public List<GameObject>[] col = new List<GameObject>[4];
    public List<GameObject> best = new List<GameObject>(4);
    public GameObject best1;
    public GameObject best2;
    public GameObject best3;
    public GameObject best4;
    public GameObject best5;
    public GameObject dummy;


    void Start()
    {
        col[0] = new List<GameObject>();
        col[1] = new List<GameObject>();
        col[2] = new List<GameObject>();
        col[3] = new List<GameObject>();
        best = new List<GameObject>(4);



        rowRot = InvaderRow.transform.rotation;
        hp = 5f;
        foreach (GameObject i in best)
        {
            i.transform.position = new Vector3(0, 10, 0);
        }
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
            for (int i = 0; i < amount; i++)
            {
                print(col[i].Count);
                col[i] = col[i].Where(item => item != null).ToList();

                // for (int x = 0; x < amount; x++)
                // {
                //     if (col[i][x] == null)
                //     {
                //         col[i].RemoveAt(i);
                //     }
                // }
            }
        }
        for (int i = 0; i < best.Count; i++)
        {
            if (best[i] == null)
            {
                best.RemoveAt(i);
            }

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

                StartCoroutine(Test());


            }
            wait = 0f;
            if ((level % 10) == 0 && level < 41)
            {
                hp += 5f;
            }
        }




    }
    IEnumerator Test()
    {


        yield return 0;
        // enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // foreach (GameObject x in enemies)
        // {
        //     print("working");
        //     if (x.transform.localPosition.x == 0)
        //     {
        //         col[0].Add(x);
        //         print("col0");
        //         print(col[0].Count);
        //     }
        //     if (x.transform.localPosition.x == -0.88)
        //     {
        //         col[1].Add(x);
        //         print("col1");
        //         print(col[1].Count);
        //     }
        //     if (x.transform.localPosition.x == (-0.88 * 2))
        //     {
        //         col[2].Add(x);
        //         print("col2");
        //     }
        //     if (x.transform.localPosition.x == (-0.88 * 3))
        //     {
        //         col[3].Add(x);
        //         print("col3");
        //     }
        //     if (x.transform.localPosition.x == (-0.88 * 4))
        //     {
        //         col[4].Add(x);
        //         print("col4");
        //     }
        // }
    }
    void ColumnManager()
    {

        // enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // for (int x = 0; x < col[0].Count(); x++)
        // {
        //     if (col[0][x] == null)
        //     {
        //         col[0].Remove(col[0][x]);
        //     }
        // }
        //something wrong with this (i think)
        // {
        // for (int x = 0; x < enemies.Count(); x++)  //something wrong with this (i think)
        // {
        //     print("help");
        //     if (enemies[x].transform.localPosition.x == 0)
        //     {
        //         col[0][x] = enemies[x];
        //         print("col0");
        //     }
        //     if (enemies[x].transform.localPosition.x == -0.88)
        //     {
        //         col[1][x] = enemies[x];
        //         print("col1");
        //     }
        //     if (enemies[x].transform.localPosition.x == (-0.88 * 2))
        //     {
        //         col[2][x] = enemies[x];
        //         print("col2");
        //     }
        //     if (enemies[x].transform.localPosition.x == (-0.88 * 3))
        //     {
        //         col[3][x] = enemies[x];
        //         print("col3");
        //     }
        //     if (enemies[x].transform.localPosition.x == (-0.88 * 4))
        //     {
        //         col[4][x] = enemies[x];
        //         print("col4");
        //     }
        // for (int x = 0; x < amount; x++)
        // {
        //     for (int y = 0; y < col[0].Count; y++)
        //     {
        //         if (col[x][y].transform.position.x == best[x].transform.position.x && col[x][y].transform.position.y < best[x].transform.position.y)
        //         {
        //             best.Add(col[x][y]);
        //         }
        //     }
        // }




        // }

        // for (int i = 0; i < col[0].Count; i++)
        // {
        //     if (col[0][i] == null)
        //     {
        //         col[0].Remove(col[0][i]);
        //     }
        //     else if (col[0][i].transform.position.y < best1.transform.position.y)
        //     {
        //         best1 = col[0][i];
        //     }
        // }
        // for (int i = 0; i < col[1].Count; i++)
        // {
        //     if (col[1][i] == null)
        //     {
        //         col[1].Remove(col[1][i]);
        //     }
        //     else if (col[1][i].transform.position.y < best2.transform.position.y)
        //     {
        //         best2 = col[1][i];
        //     }
        // }
        // for (int i = 0; i < col[2].Count; i++)
        // {
        //     if (col[2][i] == null)
        //     {
        //         col[2].Remove(col[2][i]);
        //     }
        //     else if (col[2][i].transform.position.y < best3.transform.position.y)
        //     {
        //         best3 = col[2][i];
        //     }
        // }
        // for (int i = 0; i < col[3].Count; i++)
        // {
        //     if (col[3][i] == null)
        //     {
        //         col[3].Remove(col[3][i]);
        //     }
        //     else if (col[3][i].transform.position.y < best4.transform.position.y)
        //     {
        //         best4 = col[3][i];
        //     }
        // }
        // for (int i = 0; i < col[4].Count; i++)
        // {
        //     if (col[4][i] == null)
        //     {
        //         col[4].Remove(col[4][i]);
        //     }
        //     else if (col[4][i].transform.position.y < best5.transform.position.y)
        //     {
        //         best5 = col[4][i];
        //     }
        // }
    }
}

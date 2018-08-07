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
    public Text scoreText;
    public float score;
    public GameObject[] enemies;
    public List<GameObject>[] col = new List<GameObject>[4];
    Ctrl ctrl;
    public GameObject player;

    public GameObject best1;
    public GameObject best2;
    public GameObject best3;
    public GameObject best4;
    public GameObject best5;
    public GameObject dummy;
    int lives = 3;
    public GameObject heart;
    public List<GameObject> hearts = new List<GameObject>();
    public GameObject canvas;

    Vector3 livesSpawn = new Vector3(43, 555, 0);


    void Start()
    {
        col[0] = new List<GameObject>();
        col[1] = new List<GameObject>();
        col[2] = new List<GameObject>();
        col[3] = new List<GameObject>();

        for (int i = 0; i < lives; i++)
        {
            print(i);
            GameObject x = Instantiate(heart, livesSpawn, this.transform.rotation);
            x.transform.SetParent(canvas.transform);
            hearts.Add(x.gameObject);
            livesSpawn.x += 38f;

        }

        score = 0f;
        ctrl = player.GetComponent<Ctrl>();

        rowRot = InvaderRow.transform.rotation;
        hp = 5f;
        for (int i = 0; i < amount; i++)
        {
            Instantiate(InvaderRow, spawnPos, rowRot);
            spawnPos.y -= 1;
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
                col[i] = col[i].Where(item => item != null).ToList();
            }
        }
        ScoreManager();
        ColumnManager();
        LivesManager();
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

    void ColumnManager()
    {
        for (int i = 0; i < col[0].Count; i++)
        {
            if (best1 == null)
            {
                best1 = dummy;
            }
            if (col[0][i].transform.position.y < best1.transform.position.y && col[0][i] != null)
            {
                best1 = col[0][i];
            }
        }
        for (int i = 0; i < col[1].Count; i++)
        {
            if (best2 == null)
            {
                best2 = dummy;
            }
            if (col[1][i].transform.position.y < best2.transform.position.y && col[1][i] != null)
            {
                best2 = col[1][i];
            }
        }
        for (int i = 0; i < col[2].Count; i++)
        {
            if (best3 == null)
            {
                best3 = dummy;
            }
            if (col[2][i].transform.position.y < best3.transform.position.y && col[2][i] != null)
            {
                best3 = col[2][i];
            }
        }
        for (int i = 0; i < col[3].Count; i++)
        {
            if (best4 == null)
            {
                best4 = dummy;
            }
            if (col[3][i].transform.position.y < best4.transform.position.y && col[3][i] != null)
            {
                best4 = col[3][i];
            }
        }
        // for (int i = 0; i < col[4].Count; i++)
        // {
        //     if (best5 == null)
        //     {
        //         best5 = dummy;
        //     }

        //     if (col[4][i].transform.position.y < best5.transform.position.y && col[4][i] != null)
        //     {
        //         best5 = col[4][i];
        //     }

        // }

    }
    void ScoreManager()
    {
        scoreText.text = ("Score: " + score.ToString());
    }

    void LivesManager()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (hearts[i] == null)
            {
                hearts.Remove(hearts[i]);
            }
        }
        if (ctrl.hp <= 0f)
        {
            lives--;
            ctrl.hp = ctrl.maxHp;
            int x = 0;
            for (int i = 0; i < (hearts.Count - 1); i++)
            {
                x++;
                print(x);
            }
            Destroy(hearts[x]);
        }
        if (lives == 0)
        {
            Destroy(player);
        }
    }
}

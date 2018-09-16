using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    // GameObject[] enemies;
    public List<GameObject>[] col = new List<GameObject>[4];
    Ctrl ctrl;
    public GameObject player;

    public GameObject best1;
    public GameObject best2;
    public GameObject best3;
    public GameObject best4;
    public GameObject best5;
    public GameObject dummy;
    public int lives = 3;
    public GameObject heart;
    public List<GameObject> hearts = new List<GameObject>();
    public GameObject canvas;
    public Text gameOver;
    Text text;
    public GameObject cat;
    Vector3 livesSpawn = new Vector3(43, 555, 0);
    public float special = 0f;
    float specialMax = 100f;
    float specWait = 0f;
    float specAmt;
    bool isSpecial;
    public Image SPBar;
    public Image fade;
    public GameObject scoreboard;
    public ScoreManager scoreManager;
    public GameObject bossObj;
    public GameObject fireRateGO;
    public GameObject healthGO;
    public GameObject creditsGO;
    public GameObject dark;
    public bool bossKill = false;
    public float credits = 0f;
    public Text creditsTxt;
    public GameObject shop;
    public Text creditsTxtShop;
    SpriteRenderer playerSprite;
    public GameObject[] shopItemsTxt;
    public GameObject[] shopItems;
    public Sprite pizza;
    public Sprite bullet;
    SpriteRenderer sp;


    void Start()
    {

        playerSprite = player.GetComponent<SpriteRenderer>();
        scoreManager = scoreboard.GetComponent<ScoreManager>();
        text = gameOver.GetComponent<Text>();
        text.enabled = false;
        col[0] = new List<GameObject>();
        col[1] = new List<GameObject>();
        col[2] = new List<GameObject>();
        col[3] = new List<GameObject>();

        for (int i = 0; i < lives; i++)
        {
            GameObject x = Instantiate(heart, livesSpawn, this.transform.rotation);
            x.transform.SetParent(canvas.transform);
            x.transform.localPosition = new Vector3(-130 + (38 * i), 240, 0);
            hearts.Add(x.gameObject);
            livesSpawn.x += 38f;
#if UNITY_EDITOR
            x.transform.localScale = new Vector2(.37f, .37f);
#endif

#if UNITY_STANDALONE
            x.transform.localScale = new Vector2(.37f, .37f);
#endif

#if UNITY_WEBGL
            x.transform.localScale = new Vector2(.37f, .37f);
#endif

#if UNITY_ANDROID
            x.transform.localScale = new Vector2(.37f, .37f);
#endif

        }
        credits = 0f;
        score = 0f;
        ctrl = player.GetComponent<Ctrl>();

        rowRot = InvaderRow.transform.rotation;
        hp = 5f;
        for (int i = 0; i < amount; i++)
        {
            Instantiate(InvaderRow, spawnPos, rowRot);
            spawnPos.y -= 1;
        }

        sp = ctrl.shotPrefab.GetComponent<SpriteRenderer>();
        sp.sprite = bullet;

    }

    void Update()
    {

        // enemies = GameObject.FindGameObjectsWithTag("Enemy");
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

        SpecialManager();
        if (bossKill)
        {

            Upgrade();
        }
        creditsTxt.text = "Credits: " + credits; //doesnt really need to be in the update function. Should move it out later for optimisation 
                                                 //(Probably doesnt NEED optimisation but its good to get into good habits)
    }


    void Spawn()
    {

        wait += Time.deltaTime;
        if (wait > 3)
        {
            credits += 5;
            level++;
            if ((level % 5) == 0)
            {
                hp += 5f;
                Instantiate(bossObj, new Vector3(0, 8, 0), bossObj.transform.rotation);
            }
            else
            {
                for (int i = 0; i < amount; i++)
                {
                    Instantiate(InvaderRow, spawnPos, rowRot);
                    spawnPos.y -= 1;
                }
            }
            wait = 0f;


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
                special = 0f;
            }
        }
        if (lives == 0)
        {
            Destroy(player);
            scoreManager.Score(score, level);
            text.enabled = true;
            StartCoroutine(Pause());




        }
    }

    IEnumerator Pause()
    {
        Time.timeScale = 0f;
        float x = Time.realtimeSinceStartup + 2;
        while (Time.realtimeSinceStartup < x)
        {
            yield return 0;
        }


        // colour.a += .1f;
        // fade.color = colour;
        SceneManager.LoadScene("FinalScore");
        // Time.timeScale = 1f;

    }
    void SpecialManager()
    {
        special = Mathf.Clamp(special, 0, specialMax);
        float spec = special / specialMax;
        SPBar.rectTransform.localScale = new Vector3(spec, 1, 1);
        specWait += Time.deltaTime;
        if (isSpecial)
        {
            // Time.timeScale = 0.5f;  Implement this by waiting a couple seconds after isSpecial = false and then calling this.
            if (specWait >= 0.1f)
            {
                Instantiate(cat, new Vector3(Random.Range(-2.2f, 2.2f), -6, 0), this.transform.rotation);
                specWait = 0f;
                specAmt++;
            }
            if (specAmt >= 10)
            {
                specAmt = 0f;
                special = 0f;
                isSpecial = false;
                // Time.timeScale = 1f;
            }
        }
    }
    public void SpecialActivate()
    {


        if (special >= specialMax)
        {
            isSpecial = true;

        }


    }

    void Upgrade()
    {
        Time.timeScale = 0;
        dark.SetActive(true);

    }

    public void FireRateUp()
    {
        ctrl.shotDelay *= 0.8f;
        dark.SetActive(false);
        bossKill = false;
        Time.timeScale = 0;
        if ((level % 10) == 0)
        {
            foreach (GameObject i in hearts)
            {
                Image j = i.GetComponent<Image>();
                j.enabled = false;
            }
            shop.SetActive(true);
            creditsTxtShop.text = "Credits: " + credits;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void HealthUp()
    {
        ctrl.maxHp += 5;
        ctrl.hp = ctrl.maxHp;
        dark.SetActive(false);
        bossKill = false;
        Time.timeScale = 0;
        if ((level % 10) == 0)
        {
            foreach (GameObject i in hearts)
            {
                Image j = i.GetComponent<Image>();
                j.enabled = false;
            }
            shop.SetActive(true);
            creditsTxtShop.text = "Credits: " + credits;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void CreditsUp()
    {
        credits += 50;
        dark.SetActive(false);
        bossKill = false;
        Time.timeScale = 0;
        if ((level % 10) == 0)
        {
            foreach (GameObject i in hearts)
            {
                Image j = i.GetComponent<Image>();
                j.enabled = false;
            }
            shop.gameObject.SetActive(true);
            creditsTxtShop.text = "Credits: " + credits;
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    public void RedShip() //for some reason I kept getting an error when the shop items were in another class. So theyre here now. Kill me.
    {
        if (credits >= 10)
        {
            credits -= 10;
            creditsTxtShop.text = "Credits: " + credits;
            playerSprite.color = new Color(1, 0, 0, 1);
            Text x = shopItems[0].GetComponent<Text>();
            x.text = "Purchased";
            Button y = shopItemsTxt[0].GetComponent<Button>();
            y.interactable = false;
        }
    }

    public void BlueShip()
    {
        if (credits >= 20)
        {
            credits -= 20;
            creditsTxtShop.text = "Credits: " + credits;
            playerSprite.color = new Color(0, 0, 1, 1);
            Text x = shopItems[1].GetComponent<Text>();
            x.text = "Purchased";
            Button y = shopItemsTxt[1].GetComponent<Button>();
            y.interactable = false;
        }

    }

    public void FireRate()
    {
        if (credits >= 30)
        {
            credits -= 30;
            creditsTxtShop.text = "Credits: " + credits;
            ctrl.shotDelay *= 0.8f;
            Text x = shopItems[2].GetComponent<Text>();
            x.text = "Purchased";
            Button y = shopItemsTxt[2].GetComponent<Button>();
            y.interactable = false;
        }
    }

    public void Health()
    {
        if (credits >= 30)
        {
            credits -= 30;
            creditsTxtShop.text = "Credits: " + credits;
            ctrl.maxHp += 5;
            ctrl.hp = ctrl.maxHp;
            Text x = shopItems[3].GetComponent<Text>();
            x.text = "Purchased";
            Button y = shopItemsTxt[3].GetComponent<Button>();
            y.interactable = false;
        }
    }

    public void Pizza()
    {
        if (credits >= 100)
        {
            credits -= 100;
            creditsTxtShop.text = "Credits: " + credits;
            SpriteRenderer sp = ctrl.shotPrefab.GetComponent<SpriteRenderer>();
            sp.sprite = pizza;

            Text x = shopItems[4].GetComponent<Text>();
            x.text = "Purchased";
            Button y = shopItemsTxt[4].GetComponent<Button>();
            y.interactable = false;
        }
    }

    public void Lives()
    {
        if (credits >= 50 && lives < 3)
        {
            credits -= 50;
            creditsTxtShop.text = "Credits: " + credits;
            lives++;
            GameObject j = Instantiate(heart, livesSpawn, this.transform.rotation);
            j.transform.SetParent(canvas.transform);
            j.transform.localPosition = new Vector3(-130 + (38 * hearts.Count), 240, 0);
            hearts.Add(j.gameObject);
            Image d = j.GetComponent<Image>();
            d.enabled = false;
#if UNITY_EDITOR
            j.transform.localScale = new Vector2(.37f, .37f);
#endif
            Text x = shopItems[5].GetComponent<Text>();
            x.text = "Purchased";
            Button y = shopItemsTxt[5].GetComponent<Button>();
            y.interactable = false;
        }
    }

    public void Exit()
    {
        shop.gameObject.SetActive(false);
        foreach (GameObject i in hearts)
        {
            Image j = i.GetComponent<Image>();
            j.enabled = true;
        }
        Time.timeScale = 1;
    }

}

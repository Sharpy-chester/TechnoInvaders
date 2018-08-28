using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{

    Vector3 finalPos = new Vector3(0, 1, 0);
    public float moveSpeed = 1f;
    public float hp;
    public float maxhp = 30;
    public Image hpGO;

    void Start()
    {
        hp = maxhp;
    }

    void Update()
    {
        if (this.transform.position.y > finalPos.y)
        {
            this.transform.Translate(0, (-moveSpeed * Time.deltaTime), 0);
        }
        Mathf.Clamp(this.transform.position.y, 1, 8);

        float hpBar = hp / maxhp;
        hpGO.rectTransform.localScale = new Vector3(hpBar, 1, 1);

        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public GameObject Player;


    public void L()
    {
        if (this.transform.position.x > -2.45)
        {
            Player.transform.Translate(-2f * Time.deltaTime, 0, 0);
        }
    }

    public void Unpressed()
    {
        Player.transform.Translate(0, 0, 0);
    }

    public void R()
    {
        if (this.transform.position.x < 2.45)
        {
            Player.transform.position += new Vector3(2f * Time.deltaTime, 0, 0);
        }

    }
}

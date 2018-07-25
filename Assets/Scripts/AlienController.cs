﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour {

    public float speed = 0.1f;
    float bounds = 0.88f;
    public bool right = true;
    public float down = 1f;

	void Start ()
    {
	}
	
	void FixedUpdate ()
    {
        
	}

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Movement();
        if (enemies.Length == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Movement()
    {
        if (right)
        {
            this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            if (this.transform.position.x > bounds)
            {
                this.transform.Translate (new Vector3(0, -1, 0));
                right = false;
                
            }
        }
        else
        {
            this.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            if (this.transform.position.x < -bounds)
            {
                this.transform.Translate (new Vector3(0, -1, 0));
                right = true;
                
            }
        }

    }

}
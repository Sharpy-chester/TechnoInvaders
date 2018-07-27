using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour {

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
        Movement();
        if (this.transform.childCount == 0)
        {
            GameObject controller = GameObject.Find("GameManager");
            MainController mainController = controller.GetComponent<MainController>();
            mainController.currentY = 10f;
            Destroy(this.gameObject);
        }

        //for(int i = 0; i < transform.childCount; i++)  if i need it later, this can be used for getting each 
        //{                                              of the enemies transforms in the row
        //    enemiesInRow[i] = transform.GetChild(i); 
        //}

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

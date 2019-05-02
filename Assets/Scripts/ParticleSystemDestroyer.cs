using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDestroyer : MonoBehaviour
{

    public bool destroyOnEnd;
    ParticleSystem thisSystem;

    void Awake()
    {
        thisSystem = this.GetComponent<ParticleSystem>();
    }


    void Update()
    {
        if (!thisSystem.IsAlive() && (destroyOnEnd))
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{

    public Animator camAnimator;

    public void CamShake()
    {
        camAnimator.SetTrigger("Shake");
    }
}

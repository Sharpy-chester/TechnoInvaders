using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{

    public float speed = 0.1f;

    void Update()
    {
        Material mat = this.GetComponent<MeshRenderer>().material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y -= Time.deltaTime * speed;
        mat.mainTextureOffset = offset;
    }
}

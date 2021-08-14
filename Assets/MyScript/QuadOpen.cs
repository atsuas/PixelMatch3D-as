using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadOpen : MonoBehaviour
{
    GameObject quad;
    Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        quad = GetComponent<GameObject>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            renderer.material.SetFloat("_Flip", this.GetComponent<Renderer>().material.GetFloat("_Flip") + -0.01f);
        }
    }
}

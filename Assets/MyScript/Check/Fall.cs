using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("Fall");
            rb.simulated = true;
        }
    }

}

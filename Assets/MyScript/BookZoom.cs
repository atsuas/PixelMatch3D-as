using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookZoom : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
            animator.SetTrigger("Zoom");
    }

    void Zoom()
    {
        animator.SetTrigger("Zoom");
    }
}

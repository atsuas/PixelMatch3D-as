using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookClose : MonoBehaviour
{
    Animator animator;
    public GameObject book1;
    public GameObject stage;
    public float lifeTime = 4f;
    public float destroy = 7f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("Open");
            Destroy(book1.gameObject, lifeTime);
            Destroy(this.gameObject, destroy);
        }
    }

    void Zoom()
    {
        animator.SetTrigger("Zoom");
    }

    void StageOn()
    {
        stage.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpen : MonoBehaviour
{
    Animator animator;
    public GameObject exPixel;
    public GameObject clPixel;
    public float lifeTime = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("OpenPix");
            Destroy(exPixel, lifeTime);
            Invoke("ClearPixelMatch", 1.4f);
        }
    }

    public void ClearPixelMatch()
    {
        clPixel.SetActive(true);
    }
}

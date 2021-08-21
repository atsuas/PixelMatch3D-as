using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpen : MonoBehaviour
{
    Animator animator;
    public Animator matchAnimator;
    public Animator starGoldMove;
    public Animator starGoldMove2;
    public Animator starGoldMove3;

    public GameObject exPixel;
    public GameObject clPixel;
    public GameObject nextButton;

    public GameObject starSet;
    public GameObject starGold;
    public GameObject starGold2;
    public GameObject starGold3;

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
            Invoke("StarSet", 3f);
            Invoke("StarGold", 3.6f);
            Invoke("StarGold2", 4.2f);
            Invoke("StarGold3", 4.8f);
            Invoke("NextButton", 6f);
        }
    }

    public void ClearPixelMatch()
    {
        clPixel.SetActive(true);
        matchAnimator.SetTrigger("Match");
    }

    public void StarSet()
    {
        starSet.SetActive(true);
    }

    public void StarGold()
    {
        starGold.SetActive(true);
        starGoldMove.SetBool("StarGoldMove", true);
    }

    public void StarGold2()
    {
        starGold2.SetActive(true);
        starGoldMove2.SetBool("StarGoldMove2", true);
    }

    public void StarGold3()
    {
        starGold3.SetActive(true);
        starGoldMove3.SetBool("StarGoldMove3", true);
    }

    public void NextButton()
    {
        nextButton.SetActive(true);
    }
}

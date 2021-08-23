using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSprite : MonoBehaviour
{
    public Transform mySprite;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(mySprite, transform.position, Quaternion.identity);
        }
    }
}

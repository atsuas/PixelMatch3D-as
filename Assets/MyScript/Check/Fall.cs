using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(ParticleWorking());
    }


    IEnumerator ParticleWorking()
    {
        var particle = GetComponent<ParticleSystem>();

        yield return new WaitWhile(() => particle.IsAlive(true));
        gameObject.SetActive(false);
    }
}

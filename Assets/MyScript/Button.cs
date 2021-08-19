using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private int[,] startArrays;
    private int[,] finishArrays;

void Start()
    {
        startArrays = new int[,]
        {
            {1,1,1,1,1},
            {1,1,1,1,1},
            {1,1,1,1,1},
            {1,1,1,1,1},
            {1,1,1,1,1},
            {1,1,1,1,1},
            {1,1,1,1,1},
            {1,1,1,1,1},
            {1,1,1,1,1},
            {1,1,1,1,1}
        };

        finishArrays = new int[,]
        {
            {0,0,1,1,1},
            {0,0,1,1,1},
            {1,1,1,1,1},
            {1,1,0,0,1},
            {1,1,0,0,1},
            {1,1,1,1,1},
            {1,1,0,0,0},
            {1,1,1,0,0},
            {0,1,1,1,1},
            {0,0,1,1,1}
        };

        //配列の要素を個別に出力
        Debug.Log(startArrays[0, 0] + ":" + startArrays[0, 2]);
        Debug.Log(finishArrays[0, 0] + ":" + finishArrays[0, 3]);
        //多次元配列の要素を全出力
        foreach (var startArray in startArrays)
        {
            Debug.Log(startArray);
        }
        foreach (var finishArray in finishArrays)
        {
            Debug.Log(finishArray);
        }
    }
}

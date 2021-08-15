using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject[,] fieldBlocks;

    void Start()
    {
        fieldBlocks = new GameObject[5, 10];
        BlockArray();
    }

    void BlockArray()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                GameObject piece = Instantiate(blocks[Random.Range(0,50)]);
                piece.transform.position = new Vector3(x, y, 0);
                fieldBlocks[x, y] = piece;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject[,] fieldBlocks = new GameObject[5, 10];
    private int width = 5;
    private int height = 10;

    void Start()
    {
        fieldBlocks = new GameObject[5, 10];
        CreateBlocks();
    }

    void CreateBlocks()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int r = Random.Range(0, 5);

                var block = Instantiate(blocks[r]);

                block.transform.position = new Vector2(i, j);

                fieldBlocks[i, j] = block;
            }
        }
    }
}

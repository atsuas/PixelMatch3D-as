﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public TextAsset stageFile;
    BlockType[,] blockTable;
    BlocksController[,] blockTableobj;

    public BlocksController blockPrefab;

    void Start()
    {
        LoadStageFromText();
        DebugTable();
        CreateStage();
    }

    void CreateStage()
    {
        Vector3 halfSize = default;
        float blockSize = blockPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        halfSize.x = blockSize * (blockTable.GetLength(0) / 2);
        halfSize.y = blockSize * (blockTable.GetLength(1) / 2);

        for (int y = 0; y < blockTable.GetLength(1); y++)
        {
            for (int x = 0; x < blockTable.GetLength(0); x++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);
                BlocksController block = Instantiate(blockPrefab);
                block.SetType(blockTable[x,y]);
                Vector3 setPosition = (Vector3)position * blockSize - halfSize;
                setPosition.y *= -1;
                block.transform.position = setPosition;
            }
        }
    }

    void LoadStageFromText()
    {
        string[] lines = stageFile.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        int columns = 10;
        int rows = 5;

        blockTable = new BlockType[rows, columns];
        for (int y = 0; y < columns; y++)
        {
            string[] values = lines[y].Split(new[] { ',' });
            for (int x = 0; x < rows; x++)
            {
                if (values[x] == "0")
                {
                    blockTable[x, y] = BlockType.DEATH;
                }
                if (values[x] == "1")
                {
                    blockTable[x, y] = BlockType.ALIVE;
                }
            }
        }
    }

    public void ClickedBlock(Vector3Int center)
    {
        if (IsClear())
        {
            Debug.Log("Clear");
        }
    }

    bool IsClear()
    {
        for (int y = 0; y < blockTable.GetLength(1); y++)
        {
            for (int x = 0; x < blockTable.GetLength(0); x++)
            {
                if (blockTable[x,y] == BlockType.ALIVE)
                {
                    return false;
                }
            }
        }
        return true;
    }

    void DebugTable()
    {
        for (int y = 0; y < 10; y++)
        {
            string debugText = "";
            for (int x = 0; x < 5; x++)
            {
                debugText += blockTable[x, y] + ",";
            }
            Debug.Log(debugText);
        }
    }
}

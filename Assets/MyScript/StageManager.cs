﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public TextAsset stageFile1;
    public TextAsset stageFile2;
    BlockType[,] blockTable;
    BlocksController[,] blockTableobj;

    public BlocksController blockPrefab;

    void Start()
    {
        LoadStageFromText();
        DebugTable();
        CreateStage();

        // ステージのデータ
        var blockTable = new BlockType[,] {
            { BlockType.DEATH, BlockType.DEATH, BlockType.ALIVE , BlockType.ALIVE, BlockType.ALIVE},
            { BlockType.DEATH, BlockType.ALIVE, BlockType.ALIVE , BlockType.ALIVE, BlockType.ALIVE},
            { BlockType.ALIVE, BlockType.ALIVE, BlockType.ALIVE , BlockType.ALIVE, BlockType.ALIVE},
            { BlockType.ALIVE, BlockType.ALIVE, BlockType.DEATH , BlockType.DEATH, BlockType.ALIVE},
            { BlockType.ALIVE, BlockType.ALIVE, BlockType.DEATH , BlockType.DEATH, BlockType.ALIVE},
            { BlockType.ALIVE, BlockType.ALIVE, BlockType.ALIVE , BlockType.ALIVE, BlockType.ALIVE},
            { BlockType.ALIVE, BlockType.ALIVE, BlockType.DEATH , BlockType.DEATH, BlockType.DEATH},
            { BlockType.ALIVE, BlockType.ALIVE, BlockType.ALIVE , BlockType.DEATH, BlockType.DEATH},
            { BlockType.DEATH, BlockType.ALIVE, BlockType.ALIVE , BlockType.ALIVE, BlockType.ALIVE},
            { BlockType.DEATH, BlockType.DEATH, BlockType.ALIVE , BlockType.ALIVE, BlockType.ALIVE},
        };

        // 操作されるゲームオブジェクトが持つデータ
        var BlocksController = new BlocksController[,] {
            { new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE } },
            { new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE } },
            { new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE } },
            { new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.ALIVE } },
            { new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.ALIVE } },
            { new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE } },
            { new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.DEATH } },
            { new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.DEATH } },
            { new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE } },
            { new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.DEATH }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE }, new BlocksController {type = BlockType.ALIVE } },
        };

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
                block.Init(blockTable[x,y], position, this);
                Vector3 setPosition = (Vector3)position * blockSize - halfSize;
                setPosition.y *= (float)-1.04;
                setPosition.x *= (float)-1.04;
                block.transform.position = setPosition;
                blockTableobj[x, y] = block;
            }
        }
    }

    void LoadStageFromText()
    {
        string[] lines = stageFile1.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        int columns = 10;
        int rows = 5;

        blockTable = new BlockType[rows, columns];
        blockTableobj = new BlocksController[rows, columns];
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
        Debug.Log("ClickedBlock");
    }

    public void IsClear()
    {
            bool isSuccess = true;
            for (int y = 0; y < blockTable.GetLength(1); y++)
            {
                for (int x = 0; x < blockTable.GetLength(0); x++)
                {
                    if (blockTableobj[x, y].type != blockTable[x, y]) isSuccess = false;
                }
            }

            if (isSuccess)
            {
                Debug.Log("正解");
            }
            else
            {
                Debug.Log("不正解");
            }
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

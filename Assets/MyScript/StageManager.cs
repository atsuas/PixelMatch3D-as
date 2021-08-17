using System.Collections;
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
                setPosition.y *= -1;
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
        ClearBlocks(center);
    }

    //bool IsClear()
    //{
    //    for (int y = 0; y < blockTable.GetLength(1); y++)
    //    {
    //        for (int x = 0; x < blockTable.GetLength(0); x++)
    //        {
    //            if (stageFile2)
    //            {
    //                return false;
    //            }
    //        }
    //    }
    //    return true;
    //}

    void ClearBlocks(Vector3Int center)
    {

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

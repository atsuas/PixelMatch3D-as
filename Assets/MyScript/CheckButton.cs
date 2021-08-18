using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public TextAsset stageFile2;
    BlockType[,] blockTable;
    BlocksController[,] blockTableobj;

    StageManager stageManager;
    
    void Start()
    {
        LoadStageFromText2();
    }

    void Update()
    {
        
    }

    void LoadStageFromText2()
    {
        string[] lines = stageFile2.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
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

}

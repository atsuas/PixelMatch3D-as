using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public TextAsset stageFile;
    BlockType[,] blockTable;

    void Start()
    {
        LoadStageFromText();
        DebugTable();
    }

    void LoadStageFromText()
    {
        string[] lines = stageFile.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        int columns = 5;
        int rows = 5;

        blockTable = new BlockType[columns, rows];
        for (int y = 0; y < rows; y++)
        {
            string[] values = lines[y].Split(new[] { ',' });
            for (int x = 0; x < columns; x++)
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

    void DebugTable()
    {
        for (int y = 0; y < 5; y++)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public TextAsset stageFile1;
    public TextAsset stageFile2;
    BlockType[,] blockType;
    BlocksController[,] blockTableobj;
    List<int[]> StageDatas = new List<int[]>() { };

    public BlocksController blockPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

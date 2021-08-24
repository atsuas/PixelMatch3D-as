using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public Animator openAnimator;
    public Animator openStopAnimator;

    public GameObject clearImage;
    public GameObject stopImage;
    public GameObject okButton;
    public GameObject reloadButton;
    public GameObject handOpenSprite;

    public TextAsset stageFile1;
    public TextAsset stageFile2;
    BlockType[,] blockTable;
    BlockType[,] blockTable2;

    BlocksController[,] blockTableobj;
    BlocksController[,] blockTableobj2;

    public BlocksController blockPrefab;

    void Start()
    {
        LoadStageFromText();
        DebugTable();
        CreateStage();
        openAnimator = GetComponent<Animator>();
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
        reloadButton.SetActive(true);
        
    }

    public void LoadStageFromText()
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

    public void ClearStageText()
    {
        string[] lines = stageFile2.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        int columns = 10;
        int rows = 5;

        blockTable2 = new BlockType[rows, columns];
        blockTableobj2 = new BlocksController[rows, columns];
        for (int y = 0; y < columns; y++)
        {
            string[] values = lines[y].Split(new[] { ',' });
            for (int x = 0; x < rows; x++)
            {
                if (values[x] == "0")
                {
                    blockTable2[x, y] = BlockType.DEATH;
                }
                if (values[x] == "1")
                {
                    blockTable2[x, y] = BlockType.ALIVE;
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
        ClearStageText();
        bool isSuccess = true;
        for (int y = 0; y < blockTable2.GetLength(1); y++)
        {
            for (int x = 0; x < blockTable2.GetLength(0); x++)
            {
                if (blockTableobj[x,y].type != blockTable2[x,y]) isSuccess = false;
            }
        }

        if (isSuccess)
        {
            var clones = GameObject.FindGameObjectsWithTag("Yellow");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
            clearImage.SetActive(true);
            stopImage.SetActive(true);
            openAnimator.SetTrigger("OpenAni");
            openStopAnimator.SetTrigger("OpenAni2");
            Destroy(okButton.gameObject);
            Invoke("HandOpenMove", 1.2f);
            Debug.Log("正解");
            
        }
        else
        {
            //CreateStage();
            //openAnimator.SetTrigger("Open");
            Debug.Log("不正解");
        }
    }

    public void HandOpenMove()
    {
        handOpenSprite.SetActive(true);
    }

    public void Reload()
    {
        SceneManager.LoadScene("Level1");
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Level2");
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

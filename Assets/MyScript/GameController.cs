using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject twinBlocks;
    GameObject currentBlocks;
    public GameObject[,] fieldBlocks;
    List<GameObject> CheckFieldBlocks = new List<GameObject>();

    void Start()
    {
        fieldBlocks = new GameObject[6, 13];
        CreateBlocks();
        //BlockArray();
        //Debug.Log(BlockConnect(1, 1, 0));
        //StartCoroutine(EraseBlocks());
    }

    void BlockArray()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                GameObject piece = Instantiate(blocks[Random.Range(0, 4)]);
                piece.transform.position = new Vector3(x, y, 0);
                fieldBlocks[x, y] = piece;
            }
        }
    }

    public void DropBlock()
    {
        int nullCount = 0;
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 13; y++)
            {
                if (fieldBlocks[x, y] == null)
                {
                    nullCount++;
                }
                else if (nullCount > 0)
                {
                    fieldBlocks[x, y].transform.position += new Vector3(0, -nullCount, 0);
                    fieldBlocks[x, y - nullCount] = fieldBlocks[x, y];
                    fieldBlocks[x, y] = null;
                }
            }
            nullCount = 0;
        }

        //繋がっていなかったらcreateする
        if (ConnectSuccess())
        {
            StartCoroutine(EraseBlocks());
        }
        if (!ConnectSuccess())
        {
            CreateBlocks();
        }
    }

    bool ConnectSuccess()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 13; y++)
            {
                CheckFieldBlocks.Clear();
                if (BlockConnect(x, y, 0) >= 4 && fieldBlocks[x, y] != null)
                {
                    return true;
                }
            }
        }
        return false;
    }

    //4個以上になったら消す
    IEnumerator EraseBlocks()
    {
        yield return new WaitForSeconds(0.5f);
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 13; y++)
            {
                CheckFieldBlocks.Clear();
                if (BlockConnect(x, y, 0) >= 4 && fieldBlocks[x, y] != null)
                {
                    Destroy(fieldBlocks[x, y]);
                }
            }
        }
        yield return new WaitForSeconds(0.5f);
        DropBlock();
    }

    //繋がっているBlockを数える([1,1]の部分のみ)
    int BlockConnect(int x, int y, int blockConnect)
    {
        if (fieldBlocks[x, y] == null || CheckFieldBlocks.Contains(fieldBlocks[x, y]))
        {
            return blockConnect;
        }
        CheckFieldBlocks.Add(fieldBlocks[x, y]);

        blockConnect++;

        if (x != 5 && fieldBlocks[x + 1, y] != null && fieldBlocks[x, y].name == fieldBlocks[x + 1, y].name)
        {
            blockConnect = BlockConnect(x + 1, y, blockConnect);
        }
        if (x != 0 && fieldBlocks[x - 1, y] != null && fieldBlocks[x, y].name == fieldBlocks[x - 1, y].name)
        {
            blockConnect = BlockConnect(x - 1, y, blockConnect);
        }
        if (y != 0 && fieldBlocks[x, y - 1] != null && fieldBlocks[x, y].name == fieldBlocks[x, y - 1].name)
        {
            blockConnect = BlockConnect(x, y - 1, blockConnect);
        }
        if (y != 12 && fieldBlocks[x, y + 1] != null && fieldBlocks[x, y].name == fieldBlocks[x, y + 1].name)
        {
            blockConnect = BlockConnect(x, y + 1, blockConnect);
        }
        return blockConnect;
    }

    public void CreateBlocks()
    {
        //親を取得して位置指定
        currentBlocks = Instantiate(twinBlocks);
        currentBlocks.transform.position = new Vector3(2, 11, 0);

        //ブロック1を取得して位置指定
        GameObject block1 = Instantiate(blocks[Random.Range(0, 4)]);
        block1.transform.position = new Vector3(2, 11, 0);
        //currentBlocks(twinBlocks)と親子関係にする
        block1.transform.SetParent(currentBlocks.transform, true);

        //ブロック2を取得して位置指定
        GameObject block2 = Instantiate(blocks[Random.Range(0, 4)]);
        block2.transform.position = new Vector3(2, 12, 0);
        //currentBlocks(twinBlocks)と親子関係にする
        block2.transform.SetParent(currentBlocks.transform, true);
    }
}

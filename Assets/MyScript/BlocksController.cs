using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksController : MonoBehaviour
{
    float thisTime;

    void Start()
    {
        //経過時間
        thisTime = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position += new Vector3(-1, 0, 0);
            //右に+1して動けなくする
            if (!CanMove())
            {
                this.gameObject.transform.position += new Vector3(1, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += new Vector3(1, 0, 0);
            //左に-1して動けなくする
            if (!CanMove())
            {
                this.gameObject.transform.position += new Vector3(-1, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - thisTime > 0.8f)
        {
            this.gameObject.transform.position += new Vector3(0, -1, 0);
            //上に+1して動けなくする
            if (!CanMove())
            {
                this.gameObject.transform.position += new Vector3(0, 1, 0);
                ChangeFieldBlocks();
                //親子関係を解消して消す
                this.gameObject.transform.DetachChildren();
                //新しいブロックを作成する
                FindObjectOfType<GameController>().DropBlock();
                Destroy(this.gameObject, 10f);
                //オブジェクトのチェックを消す
                this.enabled = false;
            }
            thisTime = Time.time;
        }

        //Blockを下に一気に落とす
        if (Input.GetKeyDown(KeyCode.Space))
        {
            while (CanMove())
            {
                this.gameObject.transform.position += new Vector3(0, -1, 0);
            }
            if (!CanMove())
            {
                this.gameObject.transform.position += new Vector3(0, 1, 0);
                ChangeFieldBlocks();
                this.gameObject.transform.DetachChildren();
                FindObjectOfType<GameController>().DropBlock();
                Destroy(this.gameObject, 10f);
                this.enabled = false;
            }
        }

        //回転
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.transform.RotateAround(transform.position, new Vector3(0, 0, 1), 90);
            //回転しても向きを同じにする
            foreach (Transform childBlocks in transform)
            {
                childBlocks.transform.RotateAround(childBlocks.transform.position, new Vector3(0, 0, 1), -90);
            }
            if (!CanMove())
            {
                //反対回転させて回転できなくする
                this.gameObject.transform.RotateAround(transform.position, new Vector3(0, 0, 1), -90);
                foreach (Transform childBlocks in transform)
                {
                    childBlocks.transform.RotateAround(childBlocks.transform.position, new Vector3(0, 0, 1), 90);
                }
            }
        }
    }

    //動ける範囲を指定
    bool CanMove()
    {
        foreach (Transform childBlocks in transform)
        {
            int X = Mathf.RoundToInt(childBlocks.transform.position.x);
            int Y = Mathf.RoundToInt(childBlocks.transform.position.y);
            if (X < 0 || X > 5 || Y < 0)
            {
                return false;
            }
            //ブロックがあれば動けなくする
            if (FindObjectOfType<GameController>().fieldBlocks[X, Y] != null)
            {
                return false;
            }
        }
        return true;
    }

    void ChangeFieldBlocks()
    {
        foreach (Transform childBlocks in transform)
        {
            int X = Mathf.RoundToInt(childBlocks.transform.position.x);
            int Y = Mathf.RoundToInt(childBlocks.transform.position.y);
            FindObjectOfType<GameController>().fieldBlocks[X, Y] = childBlocks.gameObject;
        }
    }
}
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    DEATH,
    ALIVE,
}

public class BlocksController : MonoBehaviour
{
    public BlockType type;
    public Sprite deathSprite;
    public Sprite aliveSprite;

    SpriteRenderer spriteRenderer;

    StageManager stageManager;
    Vector3Int intPosition;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(BlockType blockType, Vector3Int position, StageManager stageManager)
    {
        intPosition = position;
        this.stageManager = stageManager;
        SetType(type);
    }

    void SetType(BlockType blockType)
    {
        type = blockType;
        SetSprite(type);
    }

    void SetSprite(BlockType type)
    {
        if (type == BlockType.DEATH)
        {
            spriteRenderer.sprite = deathSprite;
        }
        else if (type == BlockType.ALIVE)
        {
            spriteRenderer.sprite = aliveSprite;
        }
    }

    //クリックしたら実行
    public void OnBlock()
    {
        ClearBlock();
        stageManager.ClickedBlock(intPosition);
    }

    public void ClearBlock()
    {
        if (type == BlockType.DEATH)
        {
            SetType(BlockType.ALIVE);
        }
        else if (type == BlockType.ALIVE)
        {
            SetType(BlockType.DEATH);
            Destroy(this.gameObject); //ブロックを消す
        }
    }

    void OnEnable()
    {
        StartCoroutine(ParticleWorking());
    }

    IEnumerator ParticleWorking()
    {
        var particle = GetComponent<ParticleSystem>();

        yield return new WaitWhile(() => particle.IsAlive(true));
    }
}
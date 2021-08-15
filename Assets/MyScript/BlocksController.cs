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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetType(BlockType.ALIVE);
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

    public void OnBlock()
    {
        ClearBlock();
    }

    void ClearBlock()
    {
        if (type == BlockType.DEATH)
        {
            SetType(BlockType.ALIVE);
        }
        else if (type == BlockType.ALIVE)
        {
            SetType(BlockType.DEATH);
        }
    }
}
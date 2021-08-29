using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//列挙型
public enum TileType
{
    DEATH,
    ALIVE,
}

public class TileManager : MonoBehaviour
{
    public TileType type;
    public Sprite deathSprite;
    public Sprite aliveSprite;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetType(TileType.ALIVE);
    }

    //Typeを設定
    void SetType(TileType tileType)
    {
        //Typeと画像の設定がされる
        type = tileType;
        SetImage(type);
    }

    //画像を設定
    void SetImage(TileType type)
    {
        if (type == TileType.DEATH)
        {
            spriteRenderer.sprite = deathSprite;
        }
        if (type == TileType.ALIVE)
        {
            spriteRenderer.sprite = aliveSprite;
        }
    }

    void Update()
    {
        
    }
}

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
        SetImage(tileType);
    }

    //画像を設定
    void SetImage(TileType tileType)
    {
        if (type == TileType.DEATH)
        {
            spriteRenderer.sprite = deathSprite;
        }
        else if (type == TileType.ALIVE)
        {
            spriteRenderer.sprite = aliveSprite;
        }
    }

    //クリックしたら実行する
    public void OnTile()
    {
        ReverseTile();
    }

    //反転させる
    void ReverseTile()
    {
        if (type == TileType.DEATH)
        {
            //Tile情報と画像情報を取得して変更する
            SetType(TileType.ALIVE);
        }
        else if (type == TileType.ALIVE)
        {
            //Tile情報と画像情報を取得して変更する
            SetType(TileType.DEATH);
        }
    }
}

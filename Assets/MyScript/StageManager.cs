using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//テキストデータをプログラムで扱いやすい２次元配列に変換する
public class StageManager : MonoBehaviour
{
    public TextAsset stageFile;
    TileType[,] tileTable;

    public TileManager tilePrefab;
    
    void Start()
    {
        LoadStageFromText();
        DebugTable();
        //Instantiate(tilePrefab);
        CreateStage();
    }

    void CreateStage()
    {
        //中心の変数
        Vector2 halfSize;
        //1個のタイルプレハブの横幅を取得
        float tileSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        //配置されたプレハブの全体の横幅の半分
        //計算間違いが起こるので、先に２で割るのを行う
        halfSize.x = tileSize * (tileTable.GetLength(0) / 2);
        //配置されたプレハブの全体の縦幅の半分
        //計算間違いが起こるので、先に２で割るのを行う
        halfSize.y = tileSize * (tileTable.GetLength(1) / 2);


        //縦の長さを取得
        for (int y = 0; y < tileTable.GetLength(1); y++)
        {
            //横の長さを取得
            for (int x = 0; x < tileTable.GetLength(0); x++)
            {
                //タイルを生成
                TileManager tile = Instantiate(tilePrefab);
                //タイルテーブルの情報を取得して表示する
                tile.SetType(tileTable[x, y]);
                //タイルを配置するためにVector2Intの変数を作成
                Vector2Int position = new Vector2Int(x, y);
                //Textデータが反転して表示されてしまうため、SetPositionのYだけ逆にする
                Vector2 setPosition = (Vector2)position * tileSize - halfSize;
                setPosition.y *= -1;
                //タイルを配置
                //tileSizeを掛けて、halfSizeをポジションから引いてやることで中心にズラす
                tile.transform.position = setPosition;
            }
        }
    }

    void LoadStageFromText()
    {
        //1行ずつ配列に格納する,空白区切りで
        string[] lines = stageFile.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        int columns = 5;
        int rows = 5;

        tileTable = new TileType[columns, rows];

        //２次元配列
        for (int y = 0; y < columns; y++)
        {
            //一行の情報をカンマ区切りで取得する
            string[] value = lines[y].Split(new[] {','});
            for (int x = 0; x < rows; x++)
            {
                if (value[x] == "0")
                {
                    tileTable[x, y] = TileType.DEATH;
                }
                else if (value[x] == "1")
                {
                    tileTable[x, y] = TileType.ALIVE;
                }
            }
        }
    }

    //チェック用
    void DebugTable()
    {
        for (int y = 0; y < 5; y++)
        {
            string debugText = "";
            for (int x = 0; x < 5; x++)
            {
                debugText += tileTable[x, y] + ", ";
            }
            Debug.Log(debugText);
        }
    }
}

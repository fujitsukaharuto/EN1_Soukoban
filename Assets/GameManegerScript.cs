using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManegerScript : MonoBehaviour
{
    public GameObject playerPrefeb;
    int[,] map;
    GameObject[,] field;

    Vector2Int GetPlayerIndex()
    {
        Vector2Int result = new Vector2Int();
        result.Set(-1, -1);
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y,x]==null)
                {
                    continue;
                }
                if (playerPrefeb.tag == "Player") 
                {
                    result.Set(x, y);
                    return result;
                }
            }
        }
        return result;
    }
    bool MoveNumber(string tag, Vector2Int moveFrom, Vector2Int moveTo)
    {
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0))
        {
            return false;
        }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1))
        {
            return false;
        }
        //if (map[moveTo] == 2)
        //{
        //    int velocity = moveTo - moveFrom;
        //    bool success = MoveNumber(2, moveTo, moveTo + velocity);
        //    if (!success)
        //    {
        //        return false;
        //    }
        //}
        //map[moveTo] = number;
        //map[moveFrom] = 0;
        return true;
    }
    void PrintArray()
    {
        string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y,x].ToString() + ",";
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
    }

    // Start is called before the first frame update
    void Start()
    { 
        map = new int[,] {
        { 0, 0, 0, 0, 0, },
        { 0, 0, 1, 0, 0, },
        { 0, 0, 0, 0, 0, },
        };
        PrintArray();
        field = new GameObject
            [
            map.GetLength(0),
            map.GetLength(1)
            ];
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1) 
                {
                    field[y, x] = Instantiate(
                    playerPrefeb,
                    new Vector3(x, map.GetLength(0) - y, 0),
                    Quaternion.identity);
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    int playerIndex = GetPlayerIndex();
        //    MoveNumber(1,playerIndex,playerIndex+1);
        //    PrintArray();
        //}

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    int playerIndex = GetPlayerIndex();
        //    MoveNumber(1, playerIndex, playerIndex - 1);
        //    PrintArray();
        //}
    }
}

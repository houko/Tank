/**
* author: xiaomo
* github: https://github.com/xiaomoinfo
* email: xiaomo@xiamoo.info
* QQ_NO: 83387856
* Desc: 
*/

using System.Collections.Generic;
using UnityEngine;

public class GameContext
{
    public static bool isGameOver;

    public static int playerHp = 3;

    public static int score;

    public static bool isPlayerDie;

    public static readonly Dictionary<string, GameObject> gameObjectMap = new Dictionary<string, GameObject>();


    public static void reset()
    {
        gameObjectMap.Clear();
        score = 0;
        isGameOver = false;
        isPlayerDie = false;
    }
}
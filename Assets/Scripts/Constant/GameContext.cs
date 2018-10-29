/**
* author: xiaomo
* github: https://github.com/xiaomoinfo
* email: xiaomo@xiamoo.info
* QQ_NO: 83387856
* Desc: 游戏上下文,用于保存游戏状态
*/

using System.Collections.Generic;
using UnityEngine;

public class GameContext
{
    /*是否是单人游戏*/
    public static bool isSingle = true;

    /**
     * 游戏是否结束
     */
    public static bool isGameOver;

    /**
     * 玩家血量
     */
    public static int player1Hp = 3;

    public static int player2Hp = 3;

    /**
     * 玩家分数
     */
    public static int score;

    /**
     * 地图
     */
    public static readonly Dictionary<string, GameObject> gameObjectMap = new Dictionary<string, GameObject>();

    /*场上当前敌人数量*/
    public static int currentEnemyCount;


    public static void reset()
    {
        isGameOver = false;
        player1Hp = 3;
        player2Hp = 3;
        isSingle = true;
        gameObjectMap.Clear();
        score = 0;
        currentEnemyCount = 0;
    }
}
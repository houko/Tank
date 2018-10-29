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
    /**
     * 游戏是否结束
     */
    public static bool isGameOver;

    /**
     * 玩家血量
     */
    public static int playerHp = 3;

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
        playerHp = 3;
        gameObjectMap.Clear();
        score = 0;
        currentEnemyCount = 0;
    }
}
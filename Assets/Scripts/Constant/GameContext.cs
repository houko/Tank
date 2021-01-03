using System.Collections.Generic;
using UnityEngine;

namespace Constant
{
 public static class GameContext
 {
  /*是否是单人游戏*/
  public static bool IsSingle = true;

  /**
     * 游戏是否结束
     */
  public static bool IsGameOver;

  /**
     * 玩家血量
     */
  public static int Player1Hp = 3;

  public static int Player2Hp = 3;

  /**
     * 玩家分数
     */
  public static int Score;

  /**
     * 地图
     */
  public static readonly Dictionary<string, GameObject> GameObjectMap = new Dictionary<string, GameObject>();

  /*场上当前敌人数量*/
  public static int CurrentEnemyCount;


  public static void Reset()
  {
   IsGameOver = false;
   Player1Hp = 3;
   Player2Hp = 3;
   IsSingle = true;
   GameObjectMap.Clear();
   Score = 0;
   CurrentEnemyCount = 0;
  }
 }
}
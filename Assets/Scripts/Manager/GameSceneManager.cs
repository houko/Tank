using UnityEngine;
using UnityEngine.UI;

/**
*  作   者 ：胡朋
*  github : https://github.com/xiaomoinfo
*  描   述 ：
*/
public class GameSceneManager : MonoBehaviour
{
    /*敌人prefab列表*/
    private Object[] enemyList;

    private void Awake()
    {
        enemyList = Resources.LoadAll(GameConst.EnemyPrefab, typeof(GameObject));
        if (GameContext.isSingle)
        {
            GameContext.player2Hp = 0;
        }
    }

    private void Start()
    {
        InitMap();
    }


    /// <summary>
    /// 1. 创建老家
    /// 2. 创建随机地图
    /// 3. 创建玩家(特效)
    /// 4. 创建敌人(特效)
    /// </summary>
    private void InitMap()
    {
        CreateHome();
        CreatePlayer1();
        if (!GameContext.isSingle)
        {
            CreatePlayer2();
        }

        InvokeRepeating("CreateEnemy", 2f, 5f);
        CreateRandomMap();
    }


    private void CreatePlayer1()
    {
        MapFactory.CreateMapItem(GameConst.BornPrefab1, GameConst.Player1BornVector3, transform);
    }


    private void CreatePlayer2()
    {
        MapFactory.CreateMapItem(GameConst.BornPrefab2, GameConst.Player2BornVector3, transform);
    }

    private void CreateEnemy()
    {
        if (GameContext.currentEnemyCount < GameConst.maxEnemyCount)
        {
            int index = Random.Range(0, enemyList.Length);
            Vector3 pos = GameConst.EnemyBornPosList[Random.Range(0, GameConst.EnemyBornPosList.Length)];
            Instantiate(enemyList[index], pos, Quaternion.identity);
            GameContext.currentEnemyCount++;
        }
    }


    private void CreateHome()
    {
        MapFactory.CreateMapItem(GameConst.HomePrefab, GameConst.HomeVector3, transform);
        MapFactory.CreateMapItem(GameConst.WallPrefab, GameConst.HomeVector3 - new Vector3(-1, 0, 0), transform);
        MapFactory.CreateMapItem(GameConst.WallPrefab, GameConst.HomeVector3 - new Vector3(1, 0, 0), transform);
        MapFactory.CreateMapItem(GameConst.WallPrefab, GameConst.HomeVector3 + new Vector3(0, 1, 0), transform);
        MapFactory.CreateMapItem(GameConst.WallPrefab, GameConst.HomeVector3 + new Vector3(1, 1, 0), transform);
        MapFactory.CreateMapItem(GameConst.WallPrefab, GameConst.HomeVector3 + new Vector3(-1, 1, 0), transform);
    }

    /// <summary>
    /// 1. 创建墙
    /// 2. 创建砖
    /// 3. 创建草
    /// 4. 创建河
    /// </summary>
    private void CreateRandomMap()
    {
        int grassCount = Random.Range(15, 20);
        int wallCount = Random.Range(40, 60);
        int barrierCount = Random.Range(15, 30);
        int riverCount = Random.Range(15, 20);


        for (int i = 0; i < barrierCount; i++)
        {
            Vector3 pos = CreateRandomPosition();
            MapFactory.CreateMapItem(GameConst.BarrierPrefab, pos, transform);
        }

        for (int i = 0; i < riverCount; i++)
        {
            Vector3 pos = CreateRandomPosition();
            MapFactory.CreateMapItem(GameConst.RiverPrefab, pos, transform);
        }

        for (int i = 0; i < grassCount; i++)
        {
            Vector3 pos = CreateRandomPosition();
            MapFactory.CreateMapItem(GameConst.GrassPrefab, pos, transform);
        }


        for (int i = 0; i < wallCount; i++)
        {
            Vector3 pos = CreateRandomPosition();
            MapFactory.CreateMapItem(GameConst.WallPrefab, pos, transform);
        }
    }


    /// <summary>
    /// 随机空位置
    /// 
    /// </summary>
    private Vector3 CreateRandomPosition()
    {
        Vector3 pos = new Vector3(Random.Range(-10, 10), Random.Range(-8, 8), 0);
        return MapFactory.IsEmpty(pos) ? pos : CreateRandomPosition();
    }
}
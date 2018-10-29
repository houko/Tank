using UnityEngine;

/**
*  作   者 ：胡朋
*  github : https://github.com/xiaomoinfo
*  描   述 ：
*/
public class GameConst
{
    /*场上最大敌人数量*/
    public static readonly int maxEnemyCount = 5;

    /* 老家坐标*/
    public static Vector3 HomeVector3 = new Vector3(0, -8, 0);

    /*玩家出生点坐标*/
    public static Vector3 Player1BornVector3 = new Vector3(-2, -8, 0);
    public static Vector3 Player2BornVector3 = new Vector3(2, -8, 0);

    /*敌人出生点坐标*/
    public static readonly Vector3[] EnemyBornPosList =
    {
        new Vector3(-10, 9, 0),
        new Vector3(0, 9, 0),
        new Vector3(10, 9, 0)
    };


    // 地图对象
    public const string HomePrefab = "Prefabs/Map/Home";
    public const string DieHomePrefab = "Prefabs/Map/DieHome";
    public const string WallPrefab = "Prefabs/Map/Wall";
    public const string RiverPrefab = "Prefabs/Map/River";
    public const string BarrierPrefab = "Prefabs/Map/Barrier";
    public const string GrassPrefab = "Prefabs/Map/Grass";


    //玩家和敌人
    public const string Player1Prefab = "Prefabs/Tank/Player1";
    public const string Player2Prefab = "Prefabs/Tank/Player2";
    public const string EnemyPrefab = "Prefabs/Tank/Enemy";
    public const string PlayerBulletPrefab = "Prefabs/Tank/PlayerBullet";
    public const string EnemyBulletPrefab = "Prefabs/Tank/EnemyBullet";

    // 特效
    public const string BornPrefab1 = "Prefabs/Effect/Born1";
    public const string BornPrefab2 = "Prefabs/Effect/Born2";
    public const string ShieldPrefab = "Prefabs/Effect/Shield";
    public const string ExplodePrefab = "Prefabs/Effect/Explode";

    // 声音
    public const string DieAudio = "Audios/Die";
    public const string HitAudio = "Audios/Hit";
    public const string StartAudio = "Audios/Start";
    public const string FireAudio = "Audios/Fire";
    public const string DrivingAudio = "Audios/EngineDriving";
    public const string IdleAudio = "Audios/EngineIdle";
    public const string ExplosionAudio = "Audios/Explosion";

    //tag 
    public const string WallTag = "Wall";
    public const string Water = "Water";
    public const string TankTag = "Tank";
    public const string BarrierTag = "Barrier";
    public const string HomeTag = "Home";
    public const string EnemyTag = "Enemy";
}
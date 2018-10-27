using UnityEngine;

/**
*  作   者 ：胡朋
*  github : https://github.com/xiaomoinfo
*  描   述 ：
*/
public class GameConst
{
    public static bool isSingle = true;

    public static Vector3 HomeVector3 = new Vector3(0, -8, 0);
    public static Vector3 PlayerBornVector3 = new Vector3(-2, -8, 0);

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
    public const string PlayerPrefab = "Prefabs/Tank/Player";
    public const string EnemyPrefab = "Prefabs/Tank/Enemy";
    public const string PlayerBulletPrefab = "Prefabs/Tank/PlayerBullet";
    public const string EnemyBulletPrefab = "Prefabs/Tank/EnemyBullet";

    // 特效
    public const string BornPrefab = "Prefabs/Effect/Born";
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
}
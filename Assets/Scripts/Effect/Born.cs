using UnityEngine;

/**
*  作   者 ：胡朋
*  github : https://github.com/xiaomoinfo
*  描   述 ：出生脚本 播放出生动画
 * 
*/
public class Born : MonoBehaviour
{
    private Object[] enemyList;

    private int maxEnemyCount;

    private static int currentEnemyCount;


    private void Awake()
    {
        enemyList = Resources.LoadAll(GameConst.EnemyPrefab, typeof(GameObject));
        maxEnemyCount = 5;
    }


    /// <summary>
    /// 延时加载
    /// 延时销毁
    /// </summary>
    private void Start()
    {
        Invoke("BornTank", 1f);
        InvokeRepeating("BornEnemy", 1f, 5f);
        Destroy(gameObject, 1f);
    }

    /// <summary>
    /// 玩家坦克出生
    /// </summary>
    private void BornTank()
    {
        var Born = Resources.Load<GameObject>(GameConst.PlayerPrefab);
        Instantiate(Born, transform.position, Quaternion.identity);
    }

    private void BornEnemy()
    {
        if (currentEnemyCount < maxEnemyCount)
        {
            int index = Random.Range(0, enemyList.Length);
            Vector3 pos = GameConst.EnemyBornPosList[Random.Range(0, GameConst.EnemyBornPosList.Length)];
            Instantiate(enemyList[index], pos, Quaternion.identity);
            currentEnemyCount++;
        }
    }
}
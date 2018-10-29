using UnityEngine;

/**
*  作   者 ：胡朋
*  github : https://github.com/xiaomoinfo
*  描   述 ：出生特效脚本
* 1. 生成出生动画
 * 
*/
public class Born : MonoBehaviour
{
    /// <summary>
    /// 延时加载
    /// 延时销毁
    /// </summary>
    private void Start()
    {
        Invoke("BornTank", 1f);
        Destroy(gameObject, 1f);
    }

    /// <summary>
    /// 玩家坦克出生
    /// </summary>
    private void BornTank()
    {
        var player = Resources.Load<GameObject>(GameConst.PlayerPrefab);
        Instantiate(player, transform.position, Quaternion.identity);
        // 魔法盾标识
        player.transform.Find("Shield").GetComponent<Renderer>().enabled = true;
    }
}
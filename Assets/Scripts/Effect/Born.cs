using UnityEngine;

/**
*  作   者 ：胡朋
*  github : https://github.com/xiaomoinfo
*  描   述 ：出生脚本 播放出生动画
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
        Destroy(gameObject, 3f);
    }

    /// <summary>
    /// 玩家坦克出生
    /// </summary>
    private void BornTank()
    {
        var Born = Resources.Load<GameObject>(GameConst.PlayerPrefab);
        Instantiate(Born, transform.position, Quaternion.identity);
    }
}
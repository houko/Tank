using UnityEngine;

/**
 *
 * 爆炸效果时间控制
 */
public class Explode : MonoBehaviour
{
    /**
     * 动画播完之后销毁
     */
    void Start()
    {
        Destroy(gameObject, 0.167f);
    }

}
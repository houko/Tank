using UnityEngine;

namespace Effect
{
    /**
 *
 * 爆炸效果时间控制
 */
    public class ExplodeEffect : MonoBehaviour
    {
        /**
     * 动画播完之后销毁
     */
        private void Start()
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
using Constant;
using UnityEngine;

namespace Util
{
    public class MapFactory : MonoBehaviour
    {
        /// <summary>
        /// 创建地图对象
        /// </summary>
        /// <param name="goName"></param>
        /// <param name="vector3"></param>
        /// <param name="parent"></param>
        public static void CreateMapItem(string goName, Vector3 vector3, Transform parent)
        {
            var go = Resources.Load<GameObject>(goName);
            Instantiate(go, vector3, Quaternion.identity, parent);
            GameContext.GameObjectMap.Add($"{vector3.x}-{vector3.y}", go);
        }


        /// <summary>
        /// 判断该位置是否有物体
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns></returns>
        public static bool IsEmpty(Vector3 vector3)
        {
            GameContext.GameObjectMap.TryGetValue($"{vector3.x}-{vector3.y}", out var go);
            return go == null;
        }
    }
}
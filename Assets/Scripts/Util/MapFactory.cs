using UnityEngine;

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
        GameObject go = Resources.Load<GameObject>(goName);
        Instantiate(go, vector3, Quaternion.identity, parent);
        GameContext.gameObjectMap.Add(string.Format("{0}-{1}", vector3.x, vector3.y), go);
    }


    /// <summary>
    /// 判断该位置是否有物体
    /// </summary>
    /// <param name="vector3"></param>
    /// <returns></returns>
    public static bool IsEmpty(Vector3 vector3)
    {
        GameObject go;
        GameContext.gameObjectMap.TryGetValue(string.Format("{0}-{1}", vector3.x, vector3.y), out go);
        return go == null;
    }
}
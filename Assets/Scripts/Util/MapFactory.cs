using System;
using System.Collections.Generic;
using UnityEngine;


public class MapFactory : MonoBehaviour
{
    public static readonly Dictionary<string, GameObject> gameObjectMap = new Dictionary<string, GameObject>();

    public static void CreateMapItem(string goName, Vector3 vector3, Transform parent)
    {
        GameObject go = Resources.Load<GameObject>(goName);
        GameObject ret = Instantiate(go, vector3, Quaternion.identity, parent);

        gameObjectMap.Add(string.Format("{0}-{1}", vector3.x, vector3.y), go);
    }


    /// <summary>
    /// 判断该位置是否有物体
    /// </summary>
    /// <param name="vector3"></param>
    /// <returns></returns>
    public static bool IsEmpty(Vector3 vector3)
    {
        GameObject go;
        gameObjectMap.TryGetValue(string.Format("{0}-{1}", vector3.x, vector3.y), out go);
        return go == null;
    }
}
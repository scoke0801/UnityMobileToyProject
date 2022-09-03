using UnityEngine;
using System;

public class Util : MonoBehaviour
{
    /// 문자열로 Enum값을 탐색하여 반환합니다.
    public static T ParseEnum<T>(string value, bool ignoreCase = true)
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }

    /// 대상 오브젝트가 존재하면 반환하고, 없으면 추가해서 반환합니다.
    public static T GetOrAddComponent<T>(GameObject gameObject) where T : UnityEngine.Component
    {
        T component = gameObject.GetComponent<T>();
        if (component == null)
        {
            component = gameObject.AddComponent<T>();
        }
        return component;
    }

    /// 대상 오브젝트로부터 자식 Component를 탐색하여 반환합니다.
    public static T FindChild<T>(GameObject gameObject, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (gameObject == null)
        {
            return null;
        }

        if (recursive == false)
        {
            Transform transform = gameObject.transform.Find(name);
            if (transform != null)
            {
                return transform.GetComponent<T>();
            }
        }
        else
        {
            foreach (T component in gameObject.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                {
                    return component;
                }
            }
        }

        return null;
    }

    /// 대상 오브젝트로부터 자식 Component를 탐색하여 반환합니다.
    public static GameObject FindChild(GameObject gameObject, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(gameObject, name, recursive);
        if (transform != null)
        {
            return transform.gameObject;
        }
        return null;
    }

    public static GameObject GetRandomParticle(PrefabTypeName min, PrefabTypeName max)
    {
        PrefabTypeName target = (PrefabTypeName)UnityEngine.Random.Range((int)min, (int)max);
        return Managers.Pool.Pop(Managers.Prefab.GetPrefab(target));
    }
     
}
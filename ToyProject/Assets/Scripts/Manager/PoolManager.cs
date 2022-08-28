using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PoolManager
{
    Dictionary<string, Pool> _pool = new Dictionary<string, Pool>();
    Transform _root;
    public void Init()
    {
        if (_root == null)
        {
            _root = new GameObject { name = "@Pool_Root" }.transform;
            Object.DontDestroyOnLoad(_root);
        }
        if (Managers.Scene.CurrentSceneType != Define.Scene.Game)
        {
            return;
        }

    }
    public void CreatePool(GameObject original, int count = 5)
    {
        Pool pool = new Pool();
        pool.Init(original, count); 
        pool.Root.parent = _root;

        _pool.Add(original.name, pool);
    }
    public void Push(GameObject gameObject)
    {
        string name = gameObject.name;
        if (_pool.ContainsKey(name) == false)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        _pool[name].Push(gameObject);
    }
    public GameObject Pop(GameObject original, Transform parent = null)
    {
        if (_pool.ContainsKey(original.name) == false) // Key는 원본 프리팹 이름으로 저장되므로 해당 프리팹으로 만든 오브젝트풀이 있나 검색. 
            CreatePool(original); // 없다면 새로운 풀을 만든다. 

        return _pool[original.name].Pop(parent); 
    }
    public GameObject GetOriginal(string name)
    {
        if (_pool.ContainsKey(name) == false)
        {
            return null;

        }
        return _pool[name].Original;
    }
    public void Clear()
    {
        foreach (Transform child in _root)
        {
            GameObject.Destroy(child.gameObject);
        }
        
        _pool.Clear();
    }

}
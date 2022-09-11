using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private BoxCollider _area; 

    private int _monsterCount = 0;
    private GameObject _target;

    void Start()
    {
        _area = GetComponent<BoxCollider>();
        _area.enabled = false;

        _target = Managers.Game.Player;

        for (Define.PrefabTypeName index = Define.PrefabTypeName.MONSTER_START; index <= Define.PrefabTypeName.MONSTER_END; ++index)
        {
            GameObject prefab = Managers.Prefab.GetPrefab(index);
            Managers.Pool.CreatePool(prefab, 20);
        } 
    } 

    public void Spawn()
    { 
        int selection = Random.Range((int)Define.PrefabTypeName.MONSTER_START, (int)Define.PrefabTypeName.MONSTER_END + 1); 
       
        Vector3 spawnPos; 
        while (true)
        {
            spawnPos = GetRandomPos();
            Vector3 dist = spawnPos - _target.transform.position;
            if (dist.magnitude > 20.0f && dist.magnitude < 50.0f)
            {
                break;
            } 
        } 
        float spawnAngle = Random.Range(0, 360);

        GameObject prefab = Managers.Prefab.GetPrefab((Define.PrefabTypeName)selection); 
        GameObject instance = Managers.Pool.Pop(prefab).gameObject;

        instance.transform.position = spawnPos;
        instance.SetActive(true);
        ++_monsterCount;
    }

    private Vector3 GetRandomPos()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = _area.size;

        float posX = basePosition.x + Random.Range(-size.x * 0.5f, size.x * 0.5f);
        float posY = Random.Range(0.0f, 5.0f);
        float posZ = basePosition.z + Random.Range(-size.z * 0.5f, size.z * 0.5f);

        return new Vector3(posX, posY, posZ);
    }
      
    public void RemoveObject(GameObject gameObject) 
    { 
        Managers.Pool.Push(gameObject); 
        
        --_monsterCount;
    }
    public int GetMonsterCount() { return _monsterCount; }
}

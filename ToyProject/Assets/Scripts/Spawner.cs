using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private BoxCollider area; 

    private int _monsterCount = 0;
    private GameObject _target;

    void Start()
    {
        area = GetComponent<BoxCollider>();
        area.enabled = false;

        _target = Managers.Game.Player;

        for (PrefabTypeName index = PrefabTypeName.MonsterStart; index <= PrefabTypeName.MonsterEnd; ++index)
        {
            GameObject prefab = Managers.Prefab.GetPrefab(index);
            Managers.Pool.CreatePool(prefab, 20);
        } 
    } 

    public void Spawn()
    { 
        int selection = Random.Range((int)PrefabTypeName.MonsterStart, (int)PrefabTypeName.MonsterEnd + 1); 
       
        Vector3 spawnPos;
        int count = 0;
        while (true)
        {
            spawnPos = GetRandomPos();
            Vector3 dist = spawnPos - _target.transform.position;
            if (dist.magnitude > 20.0f && dist.magnitude < 50.0f)
            {
                break;
            }
            ++count;
            if(count > 5)
            {
                break;
            }
        } 
        float spawnAngle = Random.Range(0, 360);

        GameObject prefab = Managers.Prefab.GetPrefab((PrefabTypeName)selection); 
        GameObject instance = Managers.Pool.Pop(prefab).gameObject;

        instance.transform.position = spawnPos;
        instance.SetActive(true);
        ++_monsterCount;
    }

    private Vector3 GetRandomPos()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x * 0.5f, size.x * 0.5f); 
        float posZ = basePosition.z + Random.Range(-size.z * 0.5f, size.z * 0.5f);

        return new Vector3(posX, 0, posZ);
    }
      
    public void RemoveObject(GameObject gameObject) 
    {
        Managers.Pool.Push(gameObject); 
        
        --_monsterCount;
    }
    public int GetMonsterCount() { return _monsterCount; }
}

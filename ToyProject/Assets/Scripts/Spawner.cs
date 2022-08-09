using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private BoxCollider area;

    public GameObject[] propPrefabs;

    public int count = 100;

    private List<GameObject> props = new List<GameObject>();
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>();
        area.enabled = false; 
        
        target = GameManager.instance.GetPlayerObject();
    } 

    public void Spawn()
    {
        int selection = Random.Range((int)OBJECT_TYPE.OBJ_MONSTER_GHOST_MALE, (int)OBJECT_TYPE.OBJ_MONSTER_GOBLIN_FEMALE + 1); 
       
        Vector3 spawnPos;
        while (true)
        {
            spawnPos = GetRandomPos();
            Vector3 dist = spawnPos - target.transform.position;
            if (dist.magnitude > 20.0f && dist.magnitude < 50.0f)
            {
                break;
            } 
        } 
        float spawnAngle = Random.Range(0, 360);
        
        GameObject instance = ObjectManager.instance.GetObject((OBJECT_TYPE)selection);
        instance.SetActive(true);
        instance.transform.position = spawnPos;
        Monster monsterScript = instance.GetComponent<Monster>();
        if (monsterScript != null)
        {
            monsterScript.Init();
        }

        props.Add(instance);  
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
        props.Remove(gameObject);
    }
    public int GetMonsterCount() { return props.Count; }
}

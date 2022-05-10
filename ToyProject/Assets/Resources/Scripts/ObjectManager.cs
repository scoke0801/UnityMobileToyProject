using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{ 
    public static ObjectManager instance = null;

    public int MAX_OBJECT_COUNT = 50; // 50���� ����

    Queue<GameObject>[] gameObjects;

    GameObject[] objectPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        LoadPrefabs();
        CreateObjectPool();
    }

    void CreateObjectPool()
    { 
        gameObjects = new Queue<GameObject>[(int)ObjectType.OBJ_TYPE_MAX];
        
        for (int i = (int)ObjectType.OBJ_TYPE_MIN; i < (int)ObjectType.OBJ_TYPE_MAX; ++i)
        {
            gameObjects[i] = new Queue<GameObject>();
            CreateObjects((ObjectType)i);
        } 
    }

    void LoadPrefabs()
    {
        TextAsset fileNameCSV = (TextAsset)Resources.Load("ObjectPrefabList") as TextAsset;
        string allData = fileNameCSV.text;
        string[] fileList = allData.Split('\n');

        objectPrefabs = new GameObject[(int)ObjectType.OBJ_TYPE_MAX];
        for (int i = 1; i < fileList.Length - 1; ++i)
        {
            Debug.Log(fileList[i]);
            //objectPrefabs[i - 1] = Resources.Load(fileList[i]) as GameObject;
        }

        objectPrefabs[0] = Resources.Load("Prefabs/Condor") as GameObject;
        objectPrefabs[1] = Resources.Load("Prefabs/Dragon") as GameObject;
        objectPrefabs[2] = Resources.Load("Prefabs/TempProjectile") as GameObject;
    }

    void CreateObjects(ObjectType objectType)
    { 
        GameObject targetPrefab = objectPrefabs[(int)objectType];

        if(targetPrefab == null)
        {
            Debug.LogError("---ObjectManager::CreateObjects --- failed to load prefab");
            return;
        } 
         
        for (int i = 0; i < MAX_OBJECT_COUNT; ++i)
        {
            GameObject newObject = Instantiate(targetPrefab); 
            // newObject.GetComponent<~~~>().init(this)
            newObject.SetActive(false); 
            gameObjects[(int)objectType].Enqueue(newObject);
        }
    }
   
    GameObject GetObject(ObjectType objectType)
    {  
        if(gameObjects[(int)objectType].Count <= 0)
        {
            // ������Ʈ ������ ������� Ȯ��
            return null;
        }
        // ��ü�� ���� ������ �Լ��� ȣ���� ������ �ϵ���
        return gameObjects[(int)objectType].Dequeue();
    }

    // ����� ���� ������Ʈ�� ��ȯ
    void ReturnObject(ObjectType objectType, GameObject targetObject)
    {  
        targetObject.SetActive(false);
        gameObjects[(int)objectType].Enqueue(targetObject);
    }
}

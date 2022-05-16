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
        gameObjects = new Queue<GameObject>[(int)OBJECT_TYPE.OBJ_TYPE_MAX];
        
        for (int i = (int)OBJECT_TYPE.OBJ_TYPE_MIN; i < (int)OBJECT_TYPE.OBJ_TYPE_MAX; ++i)
        {
            gameObjects[i] = new Queue<GameObject>();
            CreateObjects((OBJECT_TYPE)i);
        } 
    }

    void LoadPrefabs()
    {
        TextAsset fileNameCSV = (TextAsset)Resources.Load("ObjectPrefabList") as TextAsset; 
        string[] fileList = fileNameCSV.text.Split('\n');

        objectPrefabs = new GameObject[(int)OBJECT_TYPE.OBJ_TYPE_MAX];
        for (int i = 1; i < fileList.Length - 1; ++i)
        { 
            Debug.Log("Load Prefab -" + fileList[i]);
            
            fileList[i] = fileList[i].Replace("\r", string.Empty); 
            objectPrefabs[i - 1] = Resources.Load(fileList[i]) as GameObject;
        } 
    }

    void CreateObjects(OBJECT_TYPE objectType)
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
   
    public GameObject GetObject(OBJECT_TYPE objectType)
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
    public void ReturnObject(OBJECT_TYPE objectType, GameObject targetObject)
    { 
        targetObject.SetActive(false);
        gameObjects[(int)objectType].Enqueue(targetObject);
    } 
}

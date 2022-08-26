using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{ 
    private static ObjectManager _instance;
    public static ObjectManager instance {
        get 
        { 
            if (_instance == null)
            {
                _instance = FindObjectOfType<ObjectManager>();
            }
            return _instance;
        } 
    }

    public int MAX_OBJECT_COUNT = 20; // 20개씩 생성

    Queue<GameObject>[] gameObjects;

    public GameObject[] objectPrefabs;

    // Start is called before the first frame update
    void Start()
    { 
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
            newObject.SetActive(false);
            Monster monScript = newObject.GetComponent<Monster>();
            if (monScript)
            {
                monScript.objType = objectType;
            }
            newObject.transform.SetParent(this.gameObject.transform);
            gameObjects[(int)objectType].Enqueue(newObject);
        }
    }
   
    public GameObject GetObject(OBJECT_TYPE objectType)
    {  
        if(gameObjects[(int)objectType].Count <= 0)
        {
            // 오브젝트 개수가 충분한지 확인
            return null;
        }
        // 객체에 대한 설정은 함수를 호출한 곳에서 하도록
        return gameObjects[(int)objectType].Dequeue();
    }

    // 사용이 끝난 오브젝트를 반환
    public void ReturnObject(OBJECT_TYPE objectType, GameObject targetObject)
    { 
        targetObject.SetActive(false);
        gameObjects[(int)objectType].Enqueue(targetObject);
    } 
}

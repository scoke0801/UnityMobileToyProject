using System.Collections;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private static PrefabManager _instance;

    public static PrefabManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PrefabManager>();
            } 
            return _instance;
        } 
    }

    public void Init()
    { 
        DontDestroyOnLoad(this);
    }



}
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public enum PrefabTypeName
{ 
    None = -1,
    Player = 0,

    MonsterStart = 1,
    MonsterGhost1 = MonsterStart,
    MonsterGhost2,
    MonsterGoblinMale, 
    MonsterGoblinFemale,
    MonsterRockGolem,
    MonsterSkeletonKnight,
    MonsterSkeletonSlave,
    MonsterEnd = MonsterSkeletonSlave,

    Projectile,
    AtomBall,
    Inteceptor,
    Chicken,
    Condor,
    Spawner,

    Budy,
}
public class PrefabManager : MonoBehaviour
{
    public GameObject[] _objectPrefabs; 
    
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

    public GameObject GetPrefab(PrefabTypeName name)
    {
        return _objectPrefabs[(int)name];
    }

}
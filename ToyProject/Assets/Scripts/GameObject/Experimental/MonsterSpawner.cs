using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    const string SPAWNER_POOL_NAME = "Spawner Pool: ";
    
    [Serializable]
    class SpawnedPositionProvider : IPoolInitializer<Monster>
    {
        [SerializeField]
        BoxCollider _spawnableArea;

        public Func<Vector3> BasePositionGetter = () => Vector3.zero;
        
        Vector3 GetRandomXZPosition()
        {
            Vector3 basePosition = BasePositionGetter();
            Vector3 size = _spawnableArea.size;
                
            return new Vector3()
            {
                x = basePosition.x + UnityEngine.Random.Range(-size.x * 0.5f, size.x * 0.5f),
                y = 0.0f,
                z = basePosition.z + UnityEngine.Random.Range(-size.z * 0.5f, size.z * 0.5f)
            };
        }

        Vector3 GetSpawnXZPosition()
        {
            GameObject player = Managers.Game.Player;
            Vector3 playerPosition;
            if (player != null)
            {
                playerPosition = player.transform.position;
                playerPosition.y = 0.0f;
            }
            else
            {
                playerPosition = Vector3.zero;
            }

            while (true)
            {
                Vector3 spawnPosition = GetRandomXZPosition();
                
                float distance = (spawnPosition - playerPosition).magnitude;
                if (distance is > 20.0f and < 50.0f)
                    return spawnPosition;
            } 
        }

        void SetPosition(Monster monster)
        {
            var transform = monster.transform;
            var spawnPosition = GetSpawnXZPosition();
            
            var position = transform.position;
            position.x = spawnPosition.x;
            position.z = spawnPosition.z;

            transform.position = position;
        }
        
        public void Init(Toy.IPool<Monster> pool)
        {
            pool.OnGet -= SetPosition;
            pool.OnGet += SetPosition;
        }
    }
    
    [Serializable]
    class MonsterSpawnerPoolInitializer : IPoolInitializer<Monster>
    {
        [SerializeField]
        SpawnedPositionProvider _spawnedPositionProvider;
        
        [SerializeField]
        PoolReserver<Monster> _poolReserver;

        public void SetBaseTransform(Transform transform)
        {
            _spawnedPositionProvider.BasePositionGetter =
                () => transform != null ? transform.position : Vector3.zero;
        }

        void IPoolInitializer<Monster>.Init(Toy.IPool<Monster> pool)
        {
            _spawnedPositionProvider.Init(pool);
            _poolReserver.Init(pool);
        }
    }

    [SerializeField]
    MonsterSpawnerPoolInitializer _poolInitializer = new();
    
    [SerializeField]
    List<Monster> _prefabs = new();
    
    List<Toy.ManagedMonoBehaviourPrefabPool<Monster>> _managedPrefabPools = new();

    private IPoolInitializer<Monster> PoolInitializer => _poolInitializer;

    public int SpawnedCount
    {
        get
        {
            return _managedPrefabPools.Sum(managedPool =>
            {
                if (managedPool == null)
                    return 0;

                if (!managedPool.TryGetPool(out var pool))
                    return 0;

                return pool.SpawnedCount;
            });
        }
    }

    void PrepareManagedPools()
    {
        // 이 함수 호출이 종료되었을 때, 유효한 ManagedPool이 준비되는 것을 강력히 보장해야 한다.
        if (_managedPrefabPools.Count == 0)
        {
            for (int i = 0; i < _prefabs.Count; ++i)
                _managedPrefabPools.Add(null);
        }

        for (int i = 0; i < _prefabs.Count; ++i)
        {
            var containedPool = _managedPrefabPools[i];
            if (containedPool is {IsValid: true})
                continue;
        
            if (containedPool is {IsValid: false})
                containedPool.Release();

            var prefab = _prefabs[i];
            var preparedPool = new Toy.ManagedMonoBehaviourPrefabPool<Monster>(prefab, SPAWNER_POOL_NAME + prefab.name);
            preparedPool.Storage.SetParent(transform);
            preparedPool.TryGetPool(out var pool);
            PoolInitializer.Init(pool);

            _managedPrefabPools[i] = preparedPool;
        }
    }
    
    void Awake()
    {
        _poolInitializer.SetBaseTransform(transform);
        PrepareManagedPools();
    }

    void OnDestroy()
    {
        foreach(var managedPrefabPool in _managedPrefabPools)
            managedPrefabPool?.Release();
    }

    public Toy.Pooled<Monster> Spawn()
    {
        PrepareManagedPools();   // Runtime에서 ManagedPool가 손상되었을 경우, 유효한 ManagedPool 객체들을 준비한다.

        int selected = UnityEngine.Random.Range(0, _prefabs.Count);
        _managedPrefabPools[selected].TryGetPool(out var pool);
        return pool.Get();
    }
}
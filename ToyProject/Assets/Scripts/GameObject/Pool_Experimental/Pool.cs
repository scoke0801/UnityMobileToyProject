using System;
using System.Collections.Generic;
using UnityEngine;

// TODO: 외부 Pool 클래스들과의 이름 충돌을 방지하기 위한 임시 namespace. 추후 변경 필요.
namespace Toy
{
    public class Pool<T> : IPool<T> where T : class
    {
        private readonly Func<T> _createFunc;
        private readonly Stack<T> _despawnedObjects = new();
        private readonly HashSet<T> _spawnedObjects = new();

        public event Action<T> OnCreate = delegate { };
        public event Action<T> OnDestroy = delegate { };
        public event Action<T> OnGet = delegate { };
        public event Action<T> OnRelease = delegate { };
        
        public int Count => DespawnedCount + SpawnedCount;
        public int DespawnedCount => _despawnedObjects.Count;
        public int SpawnedCount => _spawnedObjects.Count;
        

        public Pool(Func<T> createFunc)
        {
            _createFunc = createFunc ?? throw new ArgumentException("createFunc must not be null.");
        }
        
        public bool Contains(T obj)
        {
            return IsSpawned(obj) || _despawnedObjects.Contains(obj);
        }

        public bool IsSpawned(T obj)
        {
            return _spawnedObjects.Contains(obj);
        }

        private void Create()
        {
            T obj = _createFunc();
            OnCreate(obj);

            ReleaseUnsafe(obj);
        }

        public void Reserve(int count)
        {
            int createCount = Mathf.Max(0, count - this.Count);
            for (int i = 0; i < createCount; ++i)
                Create();
        }

        public Pooled<T> Get()
        {
            if (_despawnedObjects.Count == 0)
                Create();

            T obj = _despawnedObjects.Pop();
            _spawnedObjects.Add(obj);
            
            OnGet(obj);
            return new Pooled<T>(this, obj);
        }

        void ReleaseUnsafe(T obj)
        {
            _spawnedObjects.Remove(obj);
            _despawnedObjects.Push(obj);
            OnRelease(obj);
        }

        public bool Release(T obj)
        {
            if (!IsSpawned(obj))
                return false;

            ReleaseUnsafe(obj);
            return true;
        }

        public void Clear()
        {
            var tempSpawnedObjects = new List<T>(_spawnedObjects);  // TODO: global pool을 사용한 최적화 필요.
            foreach (var obj in tempSpawnedObjects)
                ReleaseUnsafe(obj);

            foreach (var obj in _despawnedObjects)
                OnDestroy(obj);
            
            _despawnedObjects.Clear();
        }
    }
}
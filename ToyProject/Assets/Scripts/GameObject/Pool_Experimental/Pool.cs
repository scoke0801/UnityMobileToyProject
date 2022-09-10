using System;
using System.Collections.Generic;
using UnityEngine;

// TODO: 외부 Pool 클래스들과의 이름 충돌을 방지하기 위한 임시 namespace. 추후 변경 필요.
namespace Toy
{
    public class Pool<T> : IPool<T> where T : class
    {
        private readonly Func<T> _createFunc;
        private readonly Stack<T> _inactiveObjects = new();
        private readonly HashSet<T> _activeObjects = new();

        public event Action<T> OnCreate = delegate { };
        public event Action<T> OnDestroy = delegate { };
        public event Action<T> OnGet = delegate { };
        public event Action<T> OnRelease = delegate { };
        
        public int CountAll => CountInactive + CountActive;
        public int CountInactive => _inactiveObjects.Count;
        public int CountActive => _activeObjects.Count;
        

        public Pool(Func<T> createFunc)
        {
            _createFunc = createFunc ?? throw new ArgumentException("createFunc must not be null.");
        }
        
        public bool Contains(T obj)
        {
            return IsActive(obj) || IsInactive(obj);
        }

        public bool IsActive(T obj)
        {
            return _activeObjects.Contains(obj);
        }

        public bool IsInactive(T obj)
        {
            return _inactiveObjects.Contains(obj);
        }

        private void Create()
        {
            T obj = _createFunc();
            OnCreate(obj);

            ReleaseUnsafe(obj);
        }

        public void Reserve(int count)
        {
            int createCount = Mathf.Max(0, count - this.CountAll);
            for (int i = 0; i < createCount; ++i)
                Create();
        }

        public T Get()
        {
            if (_inactiveObjects.Count == 0)
                Create();

            T obj = _inactiveObjects.Pop();
            _activeObjects.Add(obj);
            
            OnGet(obj);
            return obj;
        }

        void ReleaseUnsafe(T obj)
        {
            _activeObjects.Remove(obj);
            _inactiveObjects.Push(obj);
            OnRelease(obj);
        }

        public bool Release(T obj)
        {
            if (!IsActive(obj))
                return false;

            ReleaseUnsafe(obj);
            return true;
        }

        public void Clear()
        {
            var tempSpawnedObjects = new List<T>(_activeObjects);  // TODO: global pool을 사용한 최적화 필요.
            foreach (var obj in tempSpawnedObjects)
                ReleaseUnsafe(obj);

            foreach (var obj in _inactiveObjects)
                OnDestroy(obj);
            
            _inactiveObjects.Clear();
        }
    }
}
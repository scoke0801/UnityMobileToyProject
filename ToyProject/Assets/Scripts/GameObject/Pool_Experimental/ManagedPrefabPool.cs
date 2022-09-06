using System;
using UnityEngine;

// TODO: 외부 Pool 클래스들과의 이름 충돌을 방지하기 위한 임시 namespace. 추후 변경 필요.
namespace Toy
{
    public abstract class ManagedPrefabPool<T> : IManagedPool<T> where T : UnityEngine.Object
    {
        private Transform _storage;
        private Pool<T> _poolImpl;
        
        public bool IsValid => _storage != null && _poolImpl != null;
        
        public bool IsDisposed => _storage == null && _poolImpl == null;

        public Transform Storage => _storage;

        protected abstract GameObject GetGameObjectFromInstance(T instance);
        
        protected ManagedPrefabPool(T prefab, string name)
        {
            if (prefab is not GameObject and not MonoBehaviour)
            {
                throw new ArgumentException(
                    $"prefab must be GameObject or MonoBehaviour. " +
                    $"prefab type is [{prefab.GetType().FullName}]"
                );
            }
              
            _storage = new GameObject(name).transform;
    
            _poolImpl = new Pool<T>(
                () => UnityEngine.Object.Instantiate(prefab, _storage)
            );
            _poolImpl.OnGet += instance => GetGameObjectFromInstance(instance).SetActive(true);
            _poolImpl.OnRelease += instance => GetGameObjectFromInstance(instance).SetActive(false);
            _poolImpl.OnDestroy += instance =>
            {
                if (instance == null)
                    return;

                GameObject gameObject = GetGameObjectFromInstance(instance);
                if (Application.isPlaying)
                {
                    UnityEngine.Object.Destroy(gameObject);
                }
                else
                {
                    UnityEngine.Object.DestroyImmediate(gameObject);
                }
            };
        }
    
        public bool TryGetPool(out IPool<T> pool)
        {
            if (!IsValid)
            {
                pool = null;
                return false;
            }
    
            pool = _poolImpl;
            return true;
        }
        
        public void Dispose()
        {
            if (_storage != null)
            {
                if (Application.isPlaying)
                {
                    UnityEngine.Object.Destroy(_storage);
                }
                else
                {
                    UnityEngine.Object.DestroyImmediate(_storage);
                }
                _storage = null;
            }

            if (_poolImpl != null)
            {
                _poolImpl.Clear();
                _poolImpl = null;
            }
        }
    }
}
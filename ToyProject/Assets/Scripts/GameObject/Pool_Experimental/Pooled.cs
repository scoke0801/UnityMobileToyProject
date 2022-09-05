using System;

// TODO: 외부 Pool 클래스들과의 이름 충돌을 방지하기 위한 임시 namespace. 추후 변경 필요.
namespace Toy
{
    public struct Pooled<T> : IDisposable where T : class
    {
        private IPool<T> _pool;
        private T _object;

        public bool IsValid => _pool.IsSpawned(_object);

        public T Object => _object;

        public Pooled(IPool<T> pool, T obj)
        {
            _pool = pool ?? throw new ArgumentException("pool must not be null");
            _object = obj;
        }

        public void Release()
        {
            if (_object == null)
                return;

            _pool.Release(_object);
            _object = null;
        }

        void IDisposable.Dispose()
        {
            Release();
        }
    }
}
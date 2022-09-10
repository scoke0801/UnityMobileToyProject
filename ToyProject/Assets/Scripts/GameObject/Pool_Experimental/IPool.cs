using System;

// TODO: 외부 Pool 클래스들과의 이름 충돌을 방지하기 위한 임시 namespace. 추후 변경 필요.
namespace Toy
{
    public interface IPool<T> where T : class
    {
        event Action<T> OnCreate;
        event Action<T> OnDestroy;
        event Action<T> OnGet;
        event Action<T> OnRelease;

        int CountAll { get; }
        int CountInactive { get; }
        int CountActive { get; }
        
        bool Contains(T obj);
        bool IsActive(T obj);
        
        void Reserve(int count);
        T Get();
        bool Release(T obj);
        void Clear();
    }
}
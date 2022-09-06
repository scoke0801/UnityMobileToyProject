using System;

// TODO: 외부 Pool 클래스들과의 이름 충돌을 방지하기 위한 임시 namespace. 추후 변경 필요.
namespace Toy
{
    public interface IManagedPool<T> : IDisposable where T : class
    {
        bool IsValid { get; }
        bool TryGetPool(out IPool<T> pool);
    }
}
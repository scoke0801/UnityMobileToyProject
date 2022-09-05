public interface IPoolInitializer<T> where T : class
{
    void Init(Toy.IPool<T> pool);
}
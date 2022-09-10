namespace Toy
{
    public static class IPoolExtension
    {
        public static Pooled<T> GetAsPooled<T>(this IPool<T> pool) where T : class
        {
            return new Pooled<T>(pool, pool.Get());
        }
    }
}
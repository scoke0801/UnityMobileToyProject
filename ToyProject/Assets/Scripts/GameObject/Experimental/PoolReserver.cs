using System;
using UnityEngine;

[Serializable]
public class PoolReserver<T> : IPoolInitializer<T> where T : class
{
    [SerializeField]
    int _reserveCount;

    public void Init(Toy.IPool<T> pool)
    {
        pool.Reserve(_reserveCount);
    }
}
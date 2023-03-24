using System;
using UnityEngine;

namespace Assets.Script.Pool
{
    public interface IPoolBullet<T>
    {
        public T GetResource(Type TypeRes);
        public void AddResource(T value);
        public T ActivatedComponent(Transform position, T Unit);
    }
}

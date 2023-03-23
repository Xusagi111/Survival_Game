using UnityEngine;

namespace Assets.Script.Pool
{
    public interface IPool<T>
    {
        public T UnitComponent { get; set; }
        public T ActivatedComponent(Transform position, T Unit);
    }
}

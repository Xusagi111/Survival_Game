using UnityEngine;

namespace Assets.Script.Enemy
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        public abstract void CheckUnit();
        public abstract void AttackUnit();
    }
}
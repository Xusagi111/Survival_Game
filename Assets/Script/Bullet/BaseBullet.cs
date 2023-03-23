using Assets.Script.Unit;
using UnityEngine;

namespace Assets.Script.Bullet
{
    public abstract class BaseBullet : MonoBehaviour
    {
        [SerializeField] protected Rigidbody rg;
        [SerializeField] protected float DamageBullet;

        public abstract void Move(Vector3 VelosityPos);
    }
}
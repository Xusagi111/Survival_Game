using Assets.Script.Inventory;
using Assets.Script.Pool;
using System;
using UnityEngine;

namespace Assets.Script.Bullet
{
    public abstract class BaseBullet : MonoBehaviour, IInventoryObject
    {
        [SerializeField] protected Rigidbody rg;
        [SerializeField] protected float DamageBullet;
        [SerializeField] protected float RemovalTime = 2.5f;
        protected IPool<BaseBullet> _pool;

        public bool isAffiliation { get; set; }
        public GameObject thisObj => this.gameObject;

        public Type CurrentTypeObj { get; protected set; }

        public abstract void Move(Vector3 VelosityPos, float CountXMoveBullet = 30);
        protected abstract void RemovalEndTime();

        public void Construct(IPool<BaseBullet> pool) => _pool = pool;

    }
}
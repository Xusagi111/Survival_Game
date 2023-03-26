using Assets.Script.Inventory;
using Assets.Script.Pool;
using Assets.Script.Resource;
using System;
using UnityEngine;

namespace Assets.Script.Bullet
{
    public abstract class BaseBullet : MonoBehaviour, IInventoryObject
    {
        [SerializeField] private BullletData _bulletData;
        [SerializeField] private Rigidbody _rg;
        private IPoolBullet<BaseBullet> _pool;
        protected BullletData BulletData => _bulletData;
        public bool isAffiliation { get; set; }

        public GameObject thisObj => this.gameObject;
        public Type TypeObj { get; protected set; }
        public Rigidbody Rg => _rg;
        public IPoolBullet<BaseBullet> LinkPool => _pool;

        public Sprite IconImage { get; set; }
        [SerializeField] private UIDataResource _uIDataResource;

        public UIDataResource UIDataResource => _uIDataResource;

        public abstract void Move(Vector3 VelosityPos, float CountXMoveBullet = 30);
        protected abstract void RemovalEndTime();

        public abstract void InitTypeRes();

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IUnit>(out IUnit unit)) BulletHitUnit(unit);
        }

        public virtual  void BulletHitUnit(IUnit unit)
        {
            unit.Damage.AddDamage(BulletData.DamageBullet);
            RemovalEndTime();
        }

        public void Construct(IPoolBullet<BaseBullet> pool) => _pool = pool;
    }
}
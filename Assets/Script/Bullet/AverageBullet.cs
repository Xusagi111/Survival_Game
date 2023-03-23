using Assets.Script.Pool;
using UnityEngine;

namespace Assets.Script.Bullet
{
    public class AverageBullet : BaseBullet
    {
        private void Awake() =>  CurrentTypeObj = typeof(AverageBullet);

        public override void Move(Vector3 VelosityPos, float CountXMoveBullet = 30)
        {
            rg.useGravity = true;
            rg.velocity = VelosityPos * CountXMoveBullet;
            Invoke("RemovalEndTime", RemovalTime);
            //Генерировать проджектайл, для красоты.
        }

      
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IUnit>(out IUnit unit))
            {
                unit.Damage.AddDamage(DamageBullet);
                RemovalEndTime();
            }
        }

        protected override void RemovalEndTime()
        {
            rg.useGravity = false;
            rg.velocity = Vector3.zero;
            _pool.UnitComponent = this;
        }
    }
}
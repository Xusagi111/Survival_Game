using Assets.Script.Bullet;
using Assets.Script.Pool;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Script.Gun
{
    public class AutomaticWeapons : ShootingWeapon
    {
        [SerializeField] private Transform PointToSpawnBullet;
        [SerializeField] private Type UsingBulletType;
        public const int CountMaxBullet = 30; //Состояние магазина
        public int CurrentCountBullet = 10;
        private IPoolBullet<BaseBullet> _poolBullet;

        private void Awake()
        {
            TypeObj = typeof(AutomaticWeapons);
            UsingBulletType = typeof(AverageBullet);
        }
        [Inject]
        public void Construct(AverageBullet averageBullet, IPoolBullet<BaseBullet> pool)
        {
            _poolBullet = pool;
        }

        public override void Attack()
        {
            if (CurrentCountBullet > 1) Shooting();
            else Recharge();
        }

        private void Shooting()
        {
            CurrentCountBullet--;
            var Bullet = _poolBullet.GetResource(UsingBulletType);
            _poolBullet.ActivatedComponent(PointToSpawnBullet.transform, Bullet);
            Bullet.transform.eulerAngles = PointToSpawnBullet.eulerAngles;
            Bullet.Move(PointToSpawnBullet.forward);
        }

        //Сделать перезарядку не мгновенно
        public override void Recharge()
        {
            CurrentCountBullet = CountMaxBullet;
        }
    }
}
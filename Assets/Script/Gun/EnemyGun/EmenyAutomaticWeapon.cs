using Assets.Script.Bullet;
using Assets.Script.Pool;
using Assets.Script.Resource;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Script.Gun.EnemyGun
{
    public class EmenyAutomaticWeapon : ShootingWeapon
    {
        [SerializeField] private Transform PointToSpawnBullet;
        [SerializeField] private Type UsingBulletType;
        [SerializeField] private CurrentTypeMagaze _currentTypeMagaze;
        public const int CountMaxBullet = 30;
        public int CurrentCountBullet = 0;
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
            if (CurrentCountBullet >= 1) Shooting();
            else StartRecharge();
        }

        public override bool CheckToRecharge() => true;

        public override void EndRecharge() => CurrentCountBullet = CountMaxBullet;

        public override void GetMagazeToInventory() { }
        
        public override bool Shooting()
        {
            CurrentCountBullet--;
            var Bullet = _poolBullet.GetResource(UsingBulletType);
            _poolBullet.ActivatedComponent(PointToSpawnBullet.transform, Bullet);
            Bullet.transform.eulerAngles = PointToSpawnBullet.eulerAngles;
            Bullet.Move(PointToSpawnBullet.forward);
            return true;
        }

        public override void StartRecharge()
        {
            StartCoroutine(RechargeDelay());
        }

        private IEnumerator RechargeDelay()
        {
            yield return new  WaitForSeconds(TimeColdown);
            EndRecharge();
        }
    }
}
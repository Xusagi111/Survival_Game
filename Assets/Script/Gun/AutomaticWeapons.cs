using Assets.Script.Bullet;
using Assets.Script.Pool;
using UnityEngine;
using Zenject;

namespace Assets.Script.Gun
{
    public class AutomaticWeapons : ShootingWeapon
    {
        [SerializeField] private Transform PointToSpawnBullet;
        public const int CountMaxBullet = 30; //Состояние магазина
        public int CurrentCountBullet = 10;
        private AverageBullet _prefabCreateAverageBullet;
        private IPool<BaseBullet> _poolBullet;

        private void Awake() => CurrentTypeObj = typeof(AutomaticWeapons);

        [Inject]
        public void Construct(AverageBullet averageBullet, IPool<BaseBullet> pool)
        {
            _prefabCreateAverageBullet = averageBullet;
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
            var Bullet = _poolBullet.UnitComponent;
            _poolBullet.ActivatedComponent(PointToSpawnBullet.transform, Bullet);
            Bullet.transform.eulerAngles = PointToSpawnBullet.eulerAngles;
            Bullet.Move(PointToSpawnBullet.forward);
            Bullet.Construct(_poolBullet);

        }

        //Сделать перезарядку не мгновенно
        public override void Recharge()
        {
            CurrentCountBullet = CountMaxBullet;
        }
    }
}
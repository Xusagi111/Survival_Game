using Assets.Script.Bullet;
using UnityEngine;
using Zenject;

namespace Assets.Script.Gun
{
    public class MachineGun : ShootingWeapon
    {
        [SerializeField] private Transform PointToSpawnBullet;
        public const int CountMaxBullet = 30; //Состояние магазина
        public int CurrentCountBullet = 10;
        private AverageBullet _prefabCreateAverageBullet;

        [Inject]
        public void Construct(AverageBullet averageBullet)
        {
            _prefabCreateAverageBullet = averageBullet;
        }

        public override void Attack()
        {
            if (CurrentCountBullet > 1)
            {
                CurrentCountBullet--;
                SpawnProjectile();
            }
            else
            {
                Recharge();
            }
        }

        private void SpawnProjectile()
        {
            var Bullet = Instantiate(_prefabCreateAverageBullet, PointToSpawnBullet.transform.position, Quaternion.identity);
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
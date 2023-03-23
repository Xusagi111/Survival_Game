using Assets.Script.Bullet;
using UnityEngine;
using Zenject;

namespace Assets.Script.Gun
{
    public class MachineGun : BaseWeapon, IRecharge
    {
        public Transform PointToSpawnBullet;
        public const int CountMaxBullet = 30;
        public int CurrentCountBullet = 10;
        private AverageBullet _averageBullet;

        [Inject]
        public void Construct(AverageBullet averageBullet)
        {
            _averageBullet = averageBullet;
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
            var Bullet = Instantiate(_averageBullet, PointToSpawnBullet.transform.position, Quaternion.identity);
            Bullet.transform.eulerAngles = PointToSpawnBullet.eulerAngles;
            Bullet.Move(PointToSpawnBullet.forward);
        }

        //Сделать перезарядку не мгновенно
        public void Recharge()
        {
            CurrentCountBullet = CountMaxBullet;
        }
    }
}
using UnityEngine;

namespace Assets.Script.Gun
{
    public class MachineGun : BaseWeapon, IRecharge
    {
        public Transform PointToSpawnBullet;
        public const int CountMaxBullet = 30;
        public int CurrentCountBullet = 10;


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
            var Bullet = Instantiate(AllData.instance.averageBullet, PointToSpawnBullet.transform.position, Quaternion.identity);
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
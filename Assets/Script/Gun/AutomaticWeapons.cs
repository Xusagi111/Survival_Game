using Assets.Script.Bullet;
using Assets.Script.Inventory;
using Assets.Script.Pool;
using Assets.Script.Resource;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Script.Gun
{
    public class AutomaticWeapons : ShootingWeapon
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

        public override void UsingWeapon(IInventory UsingInventory)
        {
            CurrentInventory = UsingInventory;
            EndRecharge();

        }

        public override void Attack()
        {
            if (CurrentCountBullet >= 1) Shooting();
            else StartRecharge();
        }

        private void Shooting()
        {
            CurrentCountBullet--;
            var Bullet = _poolBullet.GetResource(UsingBulletType);
            _poolBullet.ActivatedComponent(PointToSpawnBullet.transform, Bullet);
            Bullet.transform.eulerAngles = PointToSpawnBullet.eulerAngles;
            Bullet.Move(PointToSpawnBullet.forward);
            UpdateUICartridges();
        }
     
        public override void StartRecharge()
        {
            if (isRecharge == true) return;
            if (CheckToRecharge()) StartCoroutine(СountdownToRecharge());
        }

        public override void GetMagazeToInventory()
        {
            CurrentInventory.SortAllMagazineRes(UsingBulletType);
            if (CurrentInventory != null)
            {
                _currentTypeMagaze = (CurrentTypeMagaze)CurrentInventory.GetCurrentTypeInventory(UsingBulletType);
            }
        }

        private IEnumerator СountdownToRecharge()
        {
            yield return new WaitForSeconds(TimeColdown);
            EndRecharge();
            UpdateUICartridges();
        }

        public override void EndRecharge() 
        {
            GetMagazeToInventory();
            if (_currentTypeMagaze != null)
            {
                int addBullet = 0;
                int acceptableAddBullet = CountMaxBullet - CurrentCountBullet;

                if (acceptableAddBullet > _currentTypeMagaze.CurrentCount) addBullet = _currentTypeMagaze.CurrentCount;
                else addBullet = acceptableAddBullet;

                _currentTypeMagaze.RemoveInventoryObj(UsingBulletType, addBullet);
                CurrentCountBullet += addBullet;
            }
            UpdateUICartridges();
        }

        public override bool CheckToRecharge()
        {
            CurrentInventory.SortAllMagazineRes(UsingBulletType);

            var CurrentMagazine = (CurrentTypeMagaze)CurrentInventory.GetCurrentTypeInventory(UsingBulletType);

            if (CurrentMagazine != null &&
                CurrentMagazine.CurrentCount > 0) return true;
            else return false;
        }

        public void UpdateUICartridges()
        {
            EventUpdateCartridges?.Invoke(CurrentCountBullet, CountMaxBullet);
        }
    }
}
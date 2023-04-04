using Assets.Script.Inventory;
using System;
using UnityEngine.Events;

namespace Assets.Script.Gun
{
    public abstract class ShootingWeapon : BaseWeapon
    {
        public UnityEvent<int, int> EventUpdateCartridges;

        protected IInventory CurrentInventory;
        protected bool isRecharge;
        protected float TimeColdown = 1f;

        public abstract void StartRecharge();
        public abstract void EndRecharge();
        public abstract bool CheckToRecharge();

        public abstract bool Shooting();

        public virtual void UsingWeapon(IInventory UsingInventory) { }
        public abstract void GetMagazeToInventory();

        //Реализивать логику с магазнами в ShootingWeapon
        //public override void Attack()
        //{
        //    if (CurrentCountBullet >= 1) Shooting();
        //    else StartRecharge();
        //}
    }
}
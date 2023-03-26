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

        public override void Attack() { }

        public abstract void StartRecharge();
        public abstract void EndRecharge();
        public abstract bool CheckToRecharge();

        public virtual void UsingWeapon(IInventory UsingInventory) { }
        public abstract void GetMagazeToInventory();
    }
}
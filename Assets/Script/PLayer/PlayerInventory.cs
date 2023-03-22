using Assets.Script.Gun;
using Assets.Script.Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    //Определить как будет реализованы слоты у игрока
    //Сделать ограничение игрового инвентаря.

    public class PlayerInventory : MonoBehaviour, IPlayerInventory
    {
        public List<IInventoryObject> AllPlayerInventory { get; private set; } = new List<IInventoryObject>();
        public BaseWeapon ActiveWeapon { get; set; }
        [field: SerializeField] public Transform ParentToWeapon { get; set; }

        public void AddInventoryObj(IInventoryObject AddObj)
        {
            AllPlayerInventory.Add(AddObj);
        }
   
        public void RemoveInventoryObj(IInventoryObject RemoveObj)
        {
            AllPlayerInventory.Remove(RemoveObj);
        }
    }
}
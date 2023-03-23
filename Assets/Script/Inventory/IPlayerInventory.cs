using Assets.Script.Gun;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Inventory
{
    public  interface IPlayerInventory
    {
        public List<IInventoryObject> AllPlayerInventory { get;}
        public void AddInventoryObj(IInventoryObject AddObj) { }
        public void RemoveInventoryObj(IInventoryObject RemoveObj) { }
    }
}

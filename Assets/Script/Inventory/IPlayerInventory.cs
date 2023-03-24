using Assets.Script.Gun;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Inventory
{
    public  interface IPlayerInventory : IInteractionInventory<IInventoryObject>
    {
        public List<IInventoryObject> AllPlayerInventory { get;}
    }
}

using System.Collections.Generic;

namespace Assets.Script.Inventory
{
    public  interface IPlayerInventory : IInteractionInventory<IInventoryObject>
    {
        public List<IInventoryObject> AllPlayerInventory { get;}
    }
}

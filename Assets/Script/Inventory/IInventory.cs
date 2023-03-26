using System;
using System.Collections.Generic;

namespace Assets.Script.Inventory
{
    public  interface IInventory : IInteractionInventory<IInventoryObject>
    {
        public List<IInventoryObject> AllPlayerInventory { get;}

        public IInventoryObject GetCurrentTypeInventory(Type CurrentType);
        public void SortAllMagazineRes(Type TypeMagazine);

        public void MoveItemInventory(); // для интерфейса
    }
}

using Assets.Script.Inventory.InventorySystem;
using UnityEngine;

namespace Assets.Script.Inventory
{
    public class CellItem : ItemCellInventory
    {
        public CellInventory CellInventory => _cellInventory;
        [SerializeField] private CellInventory _cellInventory;

        public bool AddCellElement(IInventoryObject Element)
        {
            bool isAddElement = true;

            if (Element.CellInventory == CellInventory)
            {
                Add(Element);
                isAddElement = true;
            }
            return isAddElement;
        }

        public IInventoryObject TakeAwayCellElement()
        {
            //Может надо возвращать ошибку, вместо null
            var TakeElement = Remove();
            return TakeElement;
        }
    }
}

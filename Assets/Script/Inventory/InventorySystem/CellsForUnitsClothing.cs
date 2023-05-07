using UnityEngine;

namespace Assets.Script.Inventory.InventorySystem
{
    public class CellsForUnitsClothing : MonoBehaviour
    {
        [SerializeField] private CellItem[] clothesUnit;

        public void AddInventryObj(IInventoryObject AddObj)
        {
            foreach (var item in clothesUnit)
            {
                if (item.IsElement == false) item.AddCellElement(AddObj);
            }
        } 

        public void RemoveInventoryObj(IInventoryObject RemoveObj)
        {
            //Посмотреть полностью ли удалится объект.
            foreach (var item in clothesUnit)
            {
                if (item.IsElement == true && item.SlotItem == RemoveObj) item.TakeAwayCellElement();
            }
        }
    }
}


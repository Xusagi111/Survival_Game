using System.Collections;
using UnityEngine;

namespace Assets.Script.Inventory
{
    public interface IInteractionInventory<T>
    {
        public void AddInventoryObj(T AddObj);
        public void RemoveInventoryObj(T RemoveObj);
    }
}
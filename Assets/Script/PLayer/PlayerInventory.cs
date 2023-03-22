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

        [ContextMenu("Reset")]
        public void ResetToVector3Pos()
        {
            ActiveWeapon.isActiveWeapon = true;
            ActiveWeapon.gameObject.transform.parent = ParentToWeapon;
            ActiveWeapon.transform.position = Vector3.zero;
            ActiveWeapon.transform.localPosition = Vector3.zero;
            ActiveWeapon.transform.localEulerAngles = Vector3.zero;
            ActiveWeapon.gameObject.SetActive(true);
        }
    }
}
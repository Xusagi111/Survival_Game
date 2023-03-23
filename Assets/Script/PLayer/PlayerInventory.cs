using Assets.Script.Gun;
using Assets.Script.Inventory;
using Assets.Script.PLayer;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Script
{
    public class PlayerInventory : MonoBehaviour, IPlayerInventory
    {
        public List<IInventoryObject> AllPlayerInventory { get; private set; } = new List<IInventoryObject>();
        private PlayerView _playerView;

        [Inject]
        private void Constructor(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public void AddInventoryObj(IInventoryObject AddObj)
        {
            AllPlayerInventory.Add(AddObj);
            if (AddObj.thisObj.TryGetComponent<BaseWeapon>(out BaseWeapon Weapon))
            {
                _playerView.AddWeapon(Weapon);
            }
        }
   
        public void RemoveInventoryObj(IInventoryObject RemoveObj)
        {
            AllPlayerInventory.Remove(RemoveObj);
        }
    }
}
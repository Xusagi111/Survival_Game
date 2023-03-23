using Assets.Script.Gun;
using Assets.Script.Inventory;
using System;

namespace Assets.Script.PLayer
{

    public class PlayerCollisiоn
    {
        private BaseWeapon _addWeapon;
        private IPlayerInventory _playerInventory;
        private Action _eventGetPlayer;
        public IInventoryObject thisCollisionObj { get; private set; }
        
        public PlayerCollisiоn(IInventoryObject CollisionObject, BaseWeapon AddWeapon, IPlayerInventory PlayerInventory, Action EventGetPlayer)
        {
            _addWeapon = AddWeapon;
            _playerInventory = PlayerInventory;
            _eventGetPlayer = EventGetPlayer;
            thisCollisionObj = CollisionObject;
        }

        public void Collision()
        {
            _addWeapon.DisableComponent();
            _playerInventory.ActiveWeapon = _addWeapon;
            _playerInventory.AddInventoryObj(_addWeapon.GetComponent<IInventoryObject>());
            _eventGetPlayer?.Invoke();
        }

        public void ResetModel()
        {
            _addWeapon = null;
            _playerInventory = null;
            _eventGetPlayer = null;
        }

    }
}

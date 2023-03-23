using Assets.Script.Gun;
using Assets.Script.Inventory;
using Assets.Script.PLayer;
using Assets.Script.UI;
using System;
using UnityEngine;

namespace Assets.Script
{
    public class PlayerInput : MonoBehaviour
    {
        private IPlayerInventory _playerInventory;
        [SerializeField]  private ControllerTakingAnObjectFromScene _controllerTakingAnObjectFromScene;
        private event Action _eventplayerCollision; //костыль

        private void Awake()
        {
            _eventplayerCollision += ResetPos;
        }

        private void OnDestroy()
        {
            _eventplayerCollision -= ResetPos;
        }

        public void AddInventoryPlayer(IPlayerInventory PlayerInventory)
        {
            _playerInventory = PlayerInventory;
        }

        public void AttackEvent()
        {
            if (_playerInventory.ActiveWeapon?.isActiveWeapon == true)
            {
                _playerInventory.ActiveWeapon.Attack();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_playerInventory != null && other.TryGetComponent<IInventoryObject>(out IInventoryObject CollisObj))
            {
                if (CollisObj.isAffiliation == false &&
                    CollisObj.thisObj.TryGetComponent<BaseWeapon>(out BaseWeapon weapon))
                {
                    var PlayerCollizion = new PlayerCollisiоn(CollisObj, weapon, _playerInventory, _eventplayerCollision);
                    _controllerTakingAnObjectFromScene.SetActiveEvent(true, PlayerCollizion);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_playerInventory != null && other.TryGetComponent<IInventoryObject>(out IInventoryObject CollisObj))
            {
                if (CollisObj.isAffiliation == false &&
                    CollisObj.thisObj.TryGetComponent<BaseWeapon>(out BaseWeapon weapon))
                {
                    var PlayerCollizion = new PlayerCollisiоn(CollisObj, weapon, _playerInventory, _eventplayerCollision);
                    _controllerTakingAnObjectFromScene.SetActiveEvent(false, PlayerCollizion);
                }
            }
        }

        private void ResetPos()
        {
            Invoke("InvokeResPos", 1f);
        }

        private void InvokeResPos()
        {
            _playerInventory.ResetToVector3Pos();
        }
    }
}
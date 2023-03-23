using Assets.Script.Gun;
using Assets.Script.Inventory;
using Assets.Script.PLayer;
using Assets.Script.UI;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Script
{
    public class PlayerInput : MonoBehaviour
    {
        private IPlayerInventory _playerInventory;
        private ControllerTakingAnObjectFromScene _takingUiController;
        private event Action _eventplayerCollision; //костыль

        private void Awake()
        {
            _eventplayerCollision += ResetPos;
        }

        private void OnDestroy()
        {
            _eventplayerCollision -= ResetPos;
        }

        [Inject]
        public void Constructor(IPlayerInventory PlayerInventory, ControllerTakingAnObjectFromScene TakingUiController)
        {
            _playerInventory = PlayerInventory;
            _takingUiController = TakingUiController;
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
            if (_playerInventory != null &&
                _takingUiController != null && 
                other.TryGetComponent<IInventoryObject>(out IInventoryObject CollisObj))
            {
                if (CollisObj.isAffiliation == false &&
                    CollisObj.thisObj.TryGetComponent<BaseWeapon>(out BaseWeapon weapon))
                {
                    var PlayerCollizion = new PlayerCollisiоn(CollisObj, weapon, _playerInventory, _eventplayerCollision);
                    _takingUiController.SetActiveEvent(true, PlayerCollizion);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IInventoryObject>(out IInventoryObject CollisObj))
            {
                if (CollisObj.isAffiliation == false &&
                    CollisObj.thisObj.TryGetComponent<BaseWeapon>(out BaseWeapon weapon))
                {
                    var PlayerCollizion = new PlayerCollisiоn(CollisObj, weapon, _playerInventory, _eventplayerCollision);
                    _takingUiController.SetActiveEvent(false, PlayerCollizion);
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
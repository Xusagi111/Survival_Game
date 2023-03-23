using Assets.Script.Gun;
using Assets.Script.Inventory;
using Assets.Script.PLayer;
using Assets.Script.UI;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Script
{
    public class PlayerTriggerCollision : MonoBehaviour
    {
        private ControllerTakingAnObjectFromScene _takingUiController;

        [Inject]
        public void Constructor(ControllerTakingAnObjectFromScene TakingUiController)
        {
            _takingUiController = TakingUiController;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_takingUiController != null &&
                other.TryGetComponent<IInventoryObject>(out IInventoryObject CollisObj))
            {
                if (CollisObj.isAffiliation == false)
                {
                    _takingUiController.AddEventOpenSetButton(CollisObj);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IInventoryObject>(out IInventoryObject CollisObj))
            {
                _takingUiController.RemoveEventSetButton(CollisObj);
            }
        }
    }
}
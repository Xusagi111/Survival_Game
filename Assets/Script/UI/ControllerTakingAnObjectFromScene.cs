using Assets.Script.Inventory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Script.UI
{
    public class ControllerTakingAnObjectFromScene : MonoBehaviour
    {
        [SerializeField] private Button TakeObjectB;
        [SerializeField] private IInventory _playerInventory; 
        [SerializeField] private List<IInventoryObject> ListObjectContact = new List<IInventoryObject>();

        [Inject]
        private void Constructor(IInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }

        public void AddEventOpenSetButton(IInventoryObject ContactObj)
        {
            TakeObjectB.gameObject.SetActive(true);
            ListObjectContact.Add(ContactObj);
            TakeObjectB.onClick.AddListener(() =>
            {
                _playerInventory.AddInventoryObj(ContactObj);
                RemoveEventSetButton(ContactObj);
                ContactObj.thisObj.SetActive(false);    
            });
        }

        public void RemoveEventSetButton(IInventoryObject ContactObj)
        {
            if (ListObjectContact.IndexOf(ContactObj) != -1)
            {
                TakeObjectB.onClick.RemoveAllListeners();
                TakeObjectB.gameObject.SetActive(false);
                ListObjectContact.Remove(ContactObj);
            }
        }
    }
}
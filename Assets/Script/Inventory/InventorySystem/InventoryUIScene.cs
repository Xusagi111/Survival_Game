using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Script.Inventory.InventorySystem
{
    public class InventoryUIScene : MonoBehaviour
    {
        [SerializeField] private IInventory _playerInventory;
        [SerializeField] private GameObject InventoryWindiow; // Так же сделать спавн объектов.
        [SerializeField] private Button OpenInventoryB;

        [Inject] 
        public void Construct(IInventory PlayerINventory) => _playerInventory = PlayerINventory;

        public void OpenInventory()
        {
            if (InventoryWindiow.activeSelf == false)
            {
                //Запустить евент создания объектов.
                InventoryWindiow.SetActive(true);
            }
            else
            {
                InventoryWindiow.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            OpenInventoryB.onClick.RemoveAllListeners();
        }
    }
}
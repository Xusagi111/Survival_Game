using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Script.Inventory.InventorySystem
{
    public class InventoryUIScene : MonoBehaviour
    {
        [SerializeField] private IInventory _playerInventory;
        [SerializeField] private GameObject InventoryWindiow;
        [SerializeField] private Button[] OpenInventoryB;
        [SerializeField] private ItemCellInventory[] InventoryList;

        [Inject] 
        public void Construct(IInventory PlayerINventory) => _playerInventory = PlayerINventory;

        private void Awake() 
        {
            foreach (var item in OpenInventoryB) item.onClick.AddListener(() => ChangesStateInventory());
        }

        private void OnDestroy()
        {
            foreach (var item in OpenInventoryB) item.onClick.RemoveAllListeners();
        }

        public void ChangesStateInventory()
        {
            if (InventoryWindiow.activeSelf == false)
            {
                //Запустить евент создания объектов.
                InventoryWindiow.SetActive(true);
                OpenInventoryLogic();
            }
            else
            {
                InventoryWindiow.SetActive(false);
            }
        }

        public void OpenInventoryLogic()
        {
            Test_CLear_UI_Count_Inventory();
            
            for (int i = 0; i < _playerInventory.AllPlayerInventory.Count; i++)
            {
                var Item = _playerInventory.AllPlayerInventory[i];
                InventoryList[i].Add(Item);
            }
        }

        private void Test_CLear_UI_Count_Inventory()
        {
            for (int i = 0; i < InventoryList.Length; i++)
            {
                InventoryList[i].Clear();
            }
        }
    }
}
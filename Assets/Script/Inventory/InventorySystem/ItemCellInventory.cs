using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Inventory.InventorySystem
{
    public class ItemCellInventory : MonoBehaviour
    {
        public IInventoryObject SlotItem => _slotItem;
        public bool IsEmpty { get { return _itemCount <= 0; } }
        public bool IsElement => _isElement;

        private IInventoryObject _slotItem;
        private int _itemCount;

        [SerializeField] private Image iconImage;
        [SerializeField] private Text countText;
        [SerializeField] private bool _isCountElement = true;
        private bool _isElement;

        private void Awake()
        {
            iconImage.gameObject.SetActive(false);
            countText.text = string.Empty;
        }

        public void Add(IInventoryObject item)
        {
            _slotItem = item;
            _itemCount++;
            OnSlotModified();
        }

        public IInventoryObject Remove()
        {
            var CurentElement = _slotItem;
            OnSlotModified();
            return CurentElement;
        }

        //Removes the passed in amount of items from the slot and drops them at the dropPosition.
        public void RemoveAndDrop(int amount, Vector3 dropPosition)
        {
            OnSlotModified();
        }

        //Removes the passed in amount of items from the slot.
        public void Remove(int amount)
        {
            _itemCount -= amount > _itemCount ? _itemCount : amount;
            OnSlotModified();
        }

        //Empties the slot completely.
        public void Clear()
        {
            _itemCount = 0;
            OnSlotModified();
        }

        //Empties the slot completely and drops all the items at the dropPosition.
        public void ClearAndDrop(Vector3 dropPosition)
        {
            RemoveAndDrop(_itemCount, dropPosition);
        }

        //This method is called any time any of the variables in the slot is modified.
        private void OnSlotModified()
        {
            if (!IsEmpty)
            {
                iconImage.sprite = _slotItem.UIDataResource.IconImage;
                countText.text = _itemCount.ToString();
                iconImage.gameObject.SetActive(true);
            }
            else
            {
                _itemCount = 0;
                _slotItem = null;
                iconImage.sprite = null;
                countText.text = string.Empty;
                iconImage.gameObject.SetActive(false);
            }

            //View active to Count Text
            countText.gameObject.SetActive(_isCountElement);
        }


        //Assigns the item and itemCount directly without any pre-checks.
        //NOTE: This should only be used for loading the container slot data.
        public void SetData(IInventoryObject item, int count)
        {
            _slotItem = item;
            _itemCount = count;
            OnSlotModified();
        }
    }
}
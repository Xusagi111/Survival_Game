using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Inventory.InventorySystem
{
    public class ItemCellInventory : MonoBehaviour
    {
        public IInventoryObject slotItem;
        public int itemCount;
        public bool isUseCell;

        public bool IsEmpty { get { return itemCount <= 0; } }

        [SerializeField] private Image iconImage;

        [SerializeField] private Text countText;

        private void Awake()
        {
            iconImage.gameObject.SetActive(false);
            countText.text = string.Empty;
        }

        public void Add(IInventoryObject item)
        {
            slotItem = item;
            itemCount++;
            OnSlotModified();
        }

        //Removes the passed in amount of items from the slot and drops them at the dropPosition.
        public void RemoveAndDrop(int amount, Vector3 dropPosition)
        {
            OnSlotModified();
        }

        //Removes the passed in amount of items from the slot.
        public void Remove(int amount)
        {
            itemCount -= amount > itemCount ? itemCount : amount;
            OnSlotModified();
        }

        //Empties the slot completely.
        public void Clear()
        {
            itemCount = 0;
            OnSlotModified();
        }

        //Empties the slot completely and drops all the items at the dropPosition.
        public void ClearAndDrop(Vector3 dropPosition)
        {
            RemoveAndDrop(itemCount, dropPosition);
        }

        //This method is called any time any of the variables in the slot is modified.
        private void OnSlotModified()
        {
            if (!IsEmpty)
            {
                iconImage.sprite = slotItem.UIDataResource.IconImage;
                countText.text = itemCount.ToString();
                iconImage.gameObject.SetActive(true);
            }
            else
            {
                itemCount = 0;
                slotItem = null;
                iconImage.sprite = null;
                countText.text = string.Empty;
                iconImage.gameObject.SetActive(false);
            }
        }


        //Assigns the item and itemCount directly without any pre-checks.
        //NOTE: This should only be used for loading the container slot data.
        public void SetData(IInventoryObject item, int count)
        {
            slotItem = item;
            itemCount = count;
            OnSlotModified();
        }
    }
}
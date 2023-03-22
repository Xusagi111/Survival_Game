using Assets.Script.Gun;
using Assets.Script.Inventory;
using UnityEngine;

namespace Assets.Script
{
    //Обработка инпута игрока
    //Возможно сделать что-то подобное для противника - ии.
    public class PlayerInput : MonoBehaviour
    {
        private IPlayerInventory _playerInventory;
        
        public void AddInventoryPlayer(IPlayerInventory PlayerInventory)
        {
            _playerInventory = PlayerInventory;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _playerInventory?.ActiveWeapon.isActiveWeapon == true)
            {
                _playerInventory?.ActiveWeapon.Attack();
            }
        }

        //Реализовать пока подбор оружия с помощью коллизии,
        //A в дальнейшем сделать с помощью подбора оружия
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IInventoryObject>(out IInventoryObject CollisObj))
            {
                if (CollisObj.isAffiliation == false && _playerInventory != null)
                {
                    _playerInventory.AddInventoryObj(CollisObj);
                    if (CollisObj.thisObj.TryGetComponent<BaseWeapon>(out BaseWeapon weapon))
                    {
                        _playerInventory.ActiveWeapon = weapon;
                        weapon.isActiveWeapon = true;
                        weapon.gameObject.transform.SetParent(_playerInventory.ParentToWeapon);
                        weapon.transform.position = Vector3.zero; //TODO изменить позицию
                        Destroy(weapon.rg);
                    }
                }
            }
        }
    }
}
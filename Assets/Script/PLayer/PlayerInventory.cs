using Assets.Script.Gun;
using Assets.Script.Inventory;
using Assets.Script.PLayer;
using Assets.Script.Resource;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Script
{
    public class PlayerInventory : MonoBehaviour, IInventory
    {
        public List<IInventoryObject> AllPlayerInventory { get; private set; } = new List<IInventoryObject>();
        private PlayerView _playerView;

        [Inject]
        private void Constructor(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public void AddInventoryObj(IInventoryObject AddObj)
        {
            AddObj.isAffiliation = true;
            AllPlayerInventory.Add(AddObj);
            if (AddObj.thisObj.TryGetComponent<BaseWeapon>(out BaseWeapon Weapon))
            {
                _playerView.AddWeapon(Weapon);
            }
        }
   
        public void RemoveInventoryObj(IInventoryObject RemoveObj)
        {
            AllPlayerInventory.Remove(RemoveObj);
        }

        public IInventoryObject GetCurrentTypeInventory(Type CurrentType)
        {
            foreach (var item in AllPlayerInventory)
            {
                if (item.TypeObj == CurrentType) return item;
            }

            return null;
        }

        public void SortAllTypeRes()
        {
            throw new System.NotImplementedException();
        }

        public void MoveItemInventory()
        {
            throw new System.NotImplementedException();
        }

        //Logic Magazine
        public void SortAllMagazineRes(Type TypeMagazine)
        {
            try
            {
                var ListMagazine = new List<CurrentTypeMagaze>();
                for (int i = 0; i < AllPlayerInventory.Count; i++)
                {
                    var Item = AllPlayerInventory[i];
                    if (Item.TypeObj == TypeMagazine)
                    {
                        ListMagazine.Add((CurrentTypeMagaze)Item);
                    }
                }

                if (ListMagazine.Count >= 1)
                {
                    int AddCountBullet = 0;
                    for (int i = 1; i < ListMagazine.Count; i++)
                    {
                        AddCountBullet += ListMagazine[i].CurrentCount;
                    }
                    ListMagazine[0].AddInventoryObj(TypeMagazine, AddCountBullet);

                    for (int i = 1; i < ListMagazine.Count; i++)
                    {
                        var CurrentMagaze = ListMagazine[i];
                        AllPlayerInventory.Remove(CurrentMagaze);
                        Destroy(CurrentMagaze.gameObject);
                    }
                }
            }
            catch (Exception)
            {
                Debug.LogError("ERROR TO SORT MAGAZINE");
            }
        }
    }
}
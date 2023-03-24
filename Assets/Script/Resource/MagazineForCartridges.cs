using Assets.Script.Bullet;
using Assets.Script.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Resource
{
    public class MagazineForCartridges : MonoBehaviour, IInteractionInventory<BaseBullet>
    {
        [SerializeField] private List<BaseBullet> _listBaseBullet = new List<BaseBullet>();
        [SerializeField] private int _maxCount;
        [SerializeField] private Type Magazine;

        public int MaxCount { get => _maxCount; }

        public void AddInventoryObj(BaseBullet AddObj)
        {

        }

        public void RemoveInventoryObj(BaseBullet RemoveObj)
        {

        }
    }
}
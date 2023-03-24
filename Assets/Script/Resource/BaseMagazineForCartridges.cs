using Assets.Script.Inventory;
using System;
using UnityEngine;

namespace Assets.Script.Resource
{
    public abstract class BaseMagazineForCartridges : MonoBehaviour, IInventoryObject
    {
        [SerializeField] private int _currentCount;
        protected Type TypeMagazine;

        public int CurrentCount { get => _currentCount; }
        public bool isAffiliation { get; set; }

        public GameObject thisObj => this.gameObject;
        public Type TypeObj => TypeMagazine;

        public void AddInventoryObj(Type TypeObj, int AddCount)
        {
            if (TypeMagazine == TypeObj) _currentCount++;
        }

        public bool RemoveInventoryObj(Type TypeObj, int RemoveCount)
        {
            if (TypeMagazine == TypeObj && CurrentCount >= RemoveCount)
            {
                _currentCount -= RemoveCount;
                return true;
            }

            return false;
        }

        protected void InitTypeObj()
        {

        }
    }
}
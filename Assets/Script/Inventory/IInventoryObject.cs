using Assets.Script.Resource;
using System;
using UnityEngine;

namespace Assets.Script.Inventory
{
    public interface IInventoryObject
    {
        public UIDataResource UIDataResource { get; }
        public bool isAffiliation { get; set; }
        public GameObject thisObj { get; }
        public Type TypeObj { get; }

        public CellInventory CellInventory { get; }
    }
}

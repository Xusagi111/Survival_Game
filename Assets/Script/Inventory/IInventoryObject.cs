using System;
using UnityEngine;

namespace Assets.Script.Inventory
{
    public interface IInventoryObject
    {
        public bool isAffiliation { get; set; }
        public GameObject thisObj { get; }
        public Type TypeObj { get; }
    }
}

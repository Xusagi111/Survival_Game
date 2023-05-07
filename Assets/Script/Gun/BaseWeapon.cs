using Assets.Script.Inventory;
using Assets.Script.Resource;
using System;
using UnityEngine;

namespace Assets.Script.Gun
{
    public abstract class BaseWeapon : MonoBehaviour, IInventoryObject
    {
        public bool isActiveWeapon;
        [SerializeField] private Rigidbody rg;
        [SerializeField] private BoxCollider BoxCollider;
        public bool isAffiliation { get; set; }
        public GameObject thisObj { get => this.gameObject; }
        public Type TypeObj { get; protected set; }

        [SerializeField] private UIDataResource _uIDataResource;

        public UIDataResource UIDataResource => _uIDataResource;

       [field: SerializeField] public CellInventory CellInventory { get; }

        public virtual void Attack() { Debug.Log("Attack()"); }

        public void DisableComponent()
        {
            BoxCollider.enabled = false;
            this.gameObject.SetActive(false);
            Destroy(rg);
        }

    }
}
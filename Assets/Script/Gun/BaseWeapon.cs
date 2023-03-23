using Assets.Script.Inventory;
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
        public Type CurrentTypeObj { get; protected set; }

        public virtual void Attack() { }

        public void DisableComponent()
        {
            BoxCollider.enabled = false;
            this.gameObject.SetActive(false);
            Destroy(rg);
        }

    }
}
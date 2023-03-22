using Assets.Script.Inventory;
using UnityEngine;

namespace Assets.Script.Gun
{
    //Скриптейбл обж
    public abstract class BaseWeapon : MonoBehaviour, IInventoryObject
    {
        public bool isActiveWeapon;
        public Rigidbody rg;
        public bool isAffiliation { get; set; }
        public GameObject thisObj { get => this.gameObject; }

        public virtual void Attack() { }
    }
}
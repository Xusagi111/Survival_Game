using Assets.Script.Inventory;
using UnityEngine;

namespace Assets.Script.Gun
{
    //Скриптейбл обж
    public abstract class BaseWeapon : MonoBehaviour, IInventoryObject
    {
        public bool isActiveWeapon;
        [SerializeField] private Rigidbody rg;
        [SerializeField] private BoxCollider BoxCollider;
        public bool isAffiliation { get; set; }
        public GameObject thisObj { get => this.gameObject; }

        public virtual void Attack() { }

        public void DisableComponent()
        {
            BoxCollider.enabled = false;
            this.gameObject.SetActive(false);
            Destroy(rg);
        }
    }
}
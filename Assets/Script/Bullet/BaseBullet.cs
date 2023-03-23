using Assets.Script.Inventory;
using UnityEngine;

namespace Assets.Script.Bullet
{
    public abstract class BaseBullet : MonoBehaviour, IInventoryObject
    {
        [SerializeField] protected Rigidbody rg;
        [SerializeField] protected float DamageBullet;
        [SerializeField] protected float RemovalTime = 2.5f;

        public bool isAffiliation { get; set; }
        public GameObject thisObj => this.gameObject;

        public abstract void Move(Vector3 VelosityPos, float CountXMoveBullet = 30);
        protected abstract void RemovalEndTime();
    }
}
using System;
using UnityEngine;

namespace Assets.Script.Unit
{
    public class HealthUnit : MonoBehaviour, IDamage, IDeath
    {
        public event Action EventUpdateHealf;
        public event Action<bool> EventIsDeath;

        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        public float Health { get => _health; }
        public float MaxHealth { get => _maxHealth; }
        private bool _isDead = false;

        public bool isDead { 
            get => _isDead; 
            set
            {
                _isDead = value;
                EventIsDeath?.Invoke(_isDead);
            }
        }

        public void AddDamage(float Damage)
        {
            if (Damage >= Health)
            {
                _health = 0;
                isDead = true;
                Debug.Log("Смерть сущности");
            }
            else
            {
                _health -= Damage;
            }
            EventUpdateHealf?.Invoke();
        }
    }
}
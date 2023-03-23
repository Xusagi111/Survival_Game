using System;
using UnityEngine;

namespace Assets.Script.Unit
{
    public class HealthUnit : MonoBehaviour, IDamage
    {
        public event Action EventUpdateHealf;

        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        public float Health { get => _health; }
        public float MaxHealth { get => _maxHealth; }

        public void AddDamage(float Damage)
        {
            if (Damage >= Health)
            {
                _health = 0;
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
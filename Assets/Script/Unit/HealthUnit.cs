using UnityEngine;

namespace Assets.Script.Unit
{
    public class HealthUnit : MonoBehaviour, IDamage
    {
        [SerializeField] private float _health;
        public float Health { get => _health; }

        public void AddDamage(float Damage)
        {
            if (Damage >= Health)
            {
                _health = 0;
                Debug.Log("Смерть сущности");
            }
        }
    }
}
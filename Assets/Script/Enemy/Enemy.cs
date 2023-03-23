using Assets.Script.Unit;
using UnityEngine;

namespace Assets.Script.Enemy
{
    public class Enemy : MonoBehaviour, IUnit
    {
        [SerializeField] private HealthUnit _healthUnit;
        public IDamage Damage => _healthUnit;
    }
}
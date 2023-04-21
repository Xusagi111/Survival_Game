using Assets.Script.Gun;
using Assets.Script.Unit;
using UnityEngine;

namespace Assets.Script.Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private BaseWeapon _weapon;
        public BaseWeapon ActiveWeapon { get => _weapon; }
        [SerializeField] private HealthUnit _healthUnit;
        [SerializeField] private Animator _animatorUnit;

        public void Attack()
        {
            ActiveWeapon.Attack();
        }

        private void Awake()
        {
            _healthUnit.EventIsDeath += DeadAnimation;
        }

        private void OnDestroy()
        {
            _healthUnit.EventIsDeath -= DeadAnimation;
        }

        private void DeadAnimation(bool isDead)
        {
            _animatorUnit.SetBool("isDeath", isDead);
        }

        public void MovmentAnimvation()
        {
            Debug.Log("Todo MovmentEnemy");
        }
    }
}
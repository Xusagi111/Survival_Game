using Assets.Script.PLayer;
using Assets.Script.Unit;
using UnityEngine;
using Zenject;

namespace Assets.Script.Enemy
{
    public class Enemy : BaseEnemy, IUnit
    {
        [SerializeField] private GameObject _enemyView;
        [SerializeField] private HealthUnit _healthUnit;
        [SerializeField] private float _speedRotate;
        private IUnit _playerUnit;

        public IDamage Damage => _healthUnit;
        public IDeath Death => _healthUnit;
        protected IUnit PlayerUnit => _playerUnit;
        protected IEnemyView EnemyView => _enemyView.GetComponent<IEnemyView>();

        public Transform ThisTransform { get => this.transform;}

        [Inject]
        private void Construct(PlayerView playerView)
        {
            _playerUnit = playerView;
        }

        private void FixedUpdate() => CheckUnit();

        public override void CheckUnit()
        {
            if (Vector3.Distance(_playerUnit.ThisTransform.position, this.transform.position) < 10)
            {
                AttackUnit();
            }
        }

        public override void AttackUnit()
        {
            if (_healthUnit.isDead == true) return;

            Vector3 relativePos = _playerUnit.ThisTransform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos * 0.1f, Vector3.up);
            EnemyView.Attack();
        }
    }
}

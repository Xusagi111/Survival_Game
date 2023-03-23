using Assets.Script.PLayer;
using Assets.Script.Unit;
using UnityEngine;
using Zenject;

namespace Assets.Script.Enemy
{
    public class Enemy : MonoBehaviour, IUnit
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private HealthUnit _healthUnit;
        [SerializeField] private IUnit _playerUnit;
        [SerializeField] private float _speedRotate;

        public IDamage Damage => _healthUnit;

        public Transform ThisTransform { get => this.transform;}

        [Inject]
        private void Construct(PlayerView playerView)
        {
            _playerUnit = playerView;
        }

        private void FixedUpdate()
        {
            if (Vector3.Distance(_playerUnit.ThisTransform.position, this.transform.position) < 10)
            {
                CheckPlayer();
            }
        }

        public void CheckPlayer()
        { 
            Vector3 relativePos = _playerUnit.ThisTransform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos * 0.1f, Vector3.up);
            _enemyView.Attack();
        }
    }
}
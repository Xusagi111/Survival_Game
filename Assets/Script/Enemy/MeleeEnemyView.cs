using Assets.Script.PLayer;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Script.Enemy
{
    public class MeleeEnemyView : MonoBehaviour, IEnemyView
    {
        public const string ENEMY_MELEE_ATTACK_1 = "Attack_1";

        [SerializeField] private float DamageEnemy;
        [SerializeField] private IUnit _playerUnit;
        [SerializeField] private Animator animatior;
        private bool _isAttack;
        protected IUnit PlayerUnit => _playerUnit;

        public Transform ThisTransform { get => this.transform; }

        [Inject]
        private void Construct(PlayerView playerView) => _playerUnit = playerView;

        public void Attack()
        {
            if (CheckAttack() && PlayerUnit.Death.isDead == false)
            {
                StartCoroutine(EndAttack());
                PlayerUnit.Damage.AddDamage(DamageEnemy);
                animatior.SetTrigger(ENEMY_MELEE_ATTACK_1);
            }
        }

        private bool CheckAttack()
        {
            if (_isAttack == false) return true;
            else return false;
        }

        private IEnumerator EndAttack()
        {
            _isAttack = true;
            yield return new WaitForSeconds(1f);
            _isAttack = false;
        }
    }
}
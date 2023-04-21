using Assets.Script.PLayer;
using Assets.Script.Unit;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Script.Enemy
{
    public class MeleeEnemyView : MonoBehaviour, IEnemyView
    {
        public const string ENEMY_MELEE_ATTACK_1 = "Attack_1";
        public const string ENEMY_DEATH = "Die";
        public const string MOVMENT_ANIMATION = "Walk_Cycle_1";

        [SerializeField] private float DamageEnemy;
        [SerializeField] private HealthUnit HealthUnit;
        [SerializeField] private IUnit _playerUnit;
        [SerializeField] private Animator animatior;
        private bool _isAttack;
        protected IUnit PlayerUnit => _playerUnit;

        public Transform ThisTransform { get => this.transform; }

        [Inject]
        private void Construct(PlayerView playerView) => _playerUnit = playerView;

        private void Start()
        {
            //Возможно подписка должна осуществляться в контролере.
            HealthUnit.EventIsDeath += DeadEnemy;
        }

        private void OnDestroy()
        {
            HealthUnit.EventIsDeath -= DeadEnemy;
        }

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

        private void DeadEnemy(bool isDead)
        {
            if (isDead == true)
            {
                animatior.SetTrigger(ENEMY_DEATH);
            }
        }

        public void MovmentAnimvation()
        {
            animatior.SetTrigger(MOVMENT_ANIMATION);
        }
    }
}
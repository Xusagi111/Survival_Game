using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Script.Enemy
{
    public class MeleeUnit : Enemy
    {
        [SerializeField] private Animator _enemyAnimator; //Возможно взять с одного места, а прокидывать через ссылку.
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _timeToMove = 2f;
        private bool _isAttackUnit = false;
        private bool _isMoveUnit = false;
        private IEnumerator _attackEnemy;
        private IEnumerator _moveEmeny;

        public override void AttackUnit()
        {
            if (Death.isDead == true) return;
            _isAttackUnit = true;
            Vector3 relativePos = PlayerUnit.ThisTransform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos * 0.1f, Vector3.up);
            _attackEnemy = AttackCallback();
            StartCoroutine(_attackEnemy);
            EnemyView.Attack();
            Debug.Log("Start Enemy Attack To Player");
        }

        public override void CheckUnit()
        {
            if (Vector3.Distance(PlayerUnit.ThisTransform.position, this.transform.position) < 10)
            {
                if (_isMoveUnit == true)
                {
                    _isMoveUnit = false;
                    StopCoroutine(_moveEmeny);
                }
                AttackUnit();
            }

            if (_isAttackUnit == false && _isMoveUnit == false) MoveEnemy();
        }

        private void Start() => MoveEnemy();

        private void MoveEnemy()
        {
            if (_isAttackUnit == true) return;
            _navMeshAgent.Stop();
          
            _navMeshAgent.Move(transform.position + GenerateRandomMove());
            _moveEmeny = ContinuationMovement();
            StartCoroutine(_moveEmeny);
        }

        private IEnumerator ContinuationMovement()
        {
            _isMoveUnit = true;
            yield return new WaitForSeconds(_timeToMove);
            _isMoveUnit = false;
            MoveEnemy();
        }

        private Vector3 GenerateRandomMove()
        {
            var RandomX = Random.Range(0, 4);
            var RandomZ = Random.Range(0, 4);
            return new Vector3(RandomX, transform.position.y, RandomZ);
        }

        private IEnumerator AttackCallback()
        {
            _isAttackUnit = true;
            yield return new WaitForSeconds(1f); //Задержка между атакой (Посмотреть работает ли задаержка когда враг бьет цель.)
            _isAttackUnit = false;
        }
    }
}
using UnityEngine;

namespace Assets.Script.Enemy
{
    public class MeleeUnit : Enemy
    {
        [SerializeField] private Animator _enemyAnimator; //Возможно взять с одного места, а прокидывать через ссылку.

        public override void AttackUnit()
        {
            if (Death.isDead == true) return;

            Vector3 relativePos = PlayerUnit.ThisTransform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos * 0.1f, Vector3.up);
            EnemyView.Attack();
        }

        public override void CheckUnit()
        {
            if (Vector3.Distance(PlayerUnit.ThisTransform.position, this.transform.position) < 10)
            {
                AttackUnit();
            }
        }
    }
}
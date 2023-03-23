using Assets.Script.Gun;
using UnityEngine;

namespace Assets.Script.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private BaseWeapon _weapon;
        public BaseWeapon ActiveWeapon { get => _weapon; }

        public void Attack()
        {
            ActiveWeapon.Attack();
        }
    }
}
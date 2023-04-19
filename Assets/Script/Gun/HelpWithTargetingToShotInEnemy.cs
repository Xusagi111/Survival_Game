using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Script.Gun
{
    public class HelpWithTargetingToShotInEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private int _radius;
        [SerializeField] private LayerMask _enemyLayer;

        public void Attack()
        {
            var a = Physics.SphereCastAll(_player.transform.position, _radius, _player.transform.forward, _radius, _enemyLayer);
            var ListAllDistanseEnemy =  new List<DistanseToEnemy>();
            foreach (var item in a)
            {
                if (item.transform.gameObject.TryGetComponent<IUnit>(out IUnit HealfInstanse))
                {
                    if (HealfInstanse.Death.isDead == false)
                    {
                        float DistanceToPlayer = Vector3.Distance(_player.transform.position, item.transform.position);
                        ListAllDistanseEnemy.Add(new DistanseToEnemy(item.transform.position, DistanceToPlayer));
                    }
                }
            }

            if (ListAllDistanseEnemy.Count != 0)
            {
                var AllSortElement = SortData(ListAllDistanseEnemy);
                foreach (var item in AllSortElement)
                {
                    if (item.IsInitStruct == true)
                    {
                        Vector3 relativePos = item.PositionEnemy - transform.position;
                        Quaternion rotation = Quaternion.LookRotation(relativePos);
                        _player.transform.rotation = rotation;
                    }        
                }
            }
        }

        public IOrderedEnumerable<DistanseToEnemy> SortData(List<DistanseToEnemy> ListEnemyDistance)
        {
            var orderedNumbers = from i in ListEnemyDistance
                                 orderby i.CountDistanseToEnemy
                                 select i;
            return orderedNumbers;
        }
    }
}


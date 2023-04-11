using Assets.Script.Patrolling;
using UnityEngine;

namespace Assets.Script
{
    public class BasePointForUnit : MonoBehaviour, IBasePointForUnit
    {
        [SerializeField] private PointPatrolling[] AllPointBase;
    
        public (Transform[] AllPatrollingPoint, Transform ExpectationPoint) GetPatrolling(IUnit unit)
        {
            foreach (var item in AllPointBase)
            {
                if (item.IsAvailablePatrolling())
                {
                   return item.GetPatrollingPoint(unit);
                }
            }
            return (null, null);
        }
    }
}
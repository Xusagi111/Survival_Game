using UnityEngine;

namespace Assets.Script
{
    public interface IBasePointForUnit
    {
        public (Transform[] AllPatrollingPoint, Transform ExpectationPoint) GetPatrolling(IUnit unit);
    }
}

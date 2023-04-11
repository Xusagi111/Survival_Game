using UnityEngine;

namespace Assets.Script.Patrolling
{
    public class PointPatrolling : MonoBehaviour
    {
        [SerializeField] private Transform[] _patrollingPoint;
        [SerializeField] private Transform _expectionPoint;
        private bool _isUsingPoint;
        private IUnit _usingPlayer;

        public (Transform[] AllPatrollingPoint, Transform ExpectationPoint) GetPatrollingPoint(IUnit unit)
        {
            if (IsAvailablePatrolling())
            {
                _isUsingPoint = true;
                _usingPlayer = unit;
                return (_patrollingPoint, _expectionPoint);
            }
            else
            {
                return (null, null);
            }
        }

        public bool IsAvailablePatrolling()
        {
            if (_usingPlayer == null) _isUsingPoint = false;
            if (_isUsingPoint == false) _usingPlayer = null;
            return !_isUsingPoint;
        }
    }
}
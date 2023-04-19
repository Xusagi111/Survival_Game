using UnityEngine;

namespace Assets.Script.Gun
{
    public struct DistanseToEnemy
    {
        private readonly Vector3 _positionEnemy;
        private readonly double _countDistanseToEnemy;
        private readonly bool _isInitStruct;

        public Vector3 PositionEnemy => _positionEnemy;
        public double CountDistanseToEnemy => _countDistanseToEnemy;
        public bool IsInitStruct => _isInitStruct;

        public DistanseToEnemy(Vector3 positionEnemy, double countDistanseToEnemy)
        {
            _positionEnemy = positionEnemy;
            _countDistanseToEnemy = countDistanseToEnemy;
            _isInitStruct = true;
        }
    }
}

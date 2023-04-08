using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Assets.Script.Patrolling
{
    public class ControllerPatrolling : MonoBehaviour
    {
        //Data - возможно вынести их в другие классы
        [SerializeField] private Transform[] _pointPatroullings;
        [SerializeField] private Transform _pointToExpectation;
        private int _currnetPointPatrolling = -1;
        private float _speedPatrulling = 1f;
        private TweenerCore<Vector3, Vector3, VectorOptions> CurrentActiveTween;

        public void Start() => Patrolling();

        public void Patrolling()
        {
             var Data = GetCurrnetPoint();
             MovePosEnemy(Data.TransformPoint);
            _currnetPointPatrolling = Data.ValuePoint;
        }

        public void PausePatrolling()
        {
            CurrentActiveTween?.Restart();
           //Останавливать движение врага, и оставлять его на месте
        }

        public void StartExpectation()
        {
                
        }

        private (Transform TransformPoint, int ValuePoint) GetCurrnetPoint()
        {
            if (_pointPatroullings == null || _pointPatroullings.Length == 0) throw new Exception("ERROR TO ARRAY NULL");

            Transform EndPointPatrolling = null;
            int ValuePoint = 0;

            if (_pointPatroullings.Length <= _currnetPointPatrolling + 1) ValuePoint = 0;
            else ValuePoint = _currnetPointPatrolling + 1;

            EndPointPatrolling = _pointPatroullings[ValuePoint];
            return (EndPointPatrolling, ValuePoint);
        }

        private void MovePosEnemy(Transform MovePosition)
        {
            //Рассчитать скорость за которую он должен пройти данный участок.
           CurrentActiveTween = this.transform.DOMove(MovePosition.position, 1f).OnComplete(() =>
           {
               Debug.Log("Завершение передвижения к точке: " + MovePosition.position);
               Patrolling();
           });
        }
    }
}
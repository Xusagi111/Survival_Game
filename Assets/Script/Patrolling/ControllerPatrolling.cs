using DG.Tweening;
using System;
using UnityEngine;

namespace Assets.Script.Patrolling
{
    public class ControllerPatrolling : MonoBehaviour
    {
        private Transform[] _patroullingsPoint;
        private Transform _expectationPoint;
        private Animator _animatorUnit;
        private IBasePointForUnit _basePointForUnit;

        private int _currnetPointPatrolling = -1;
        private float _speedPatrulling = 3f;
        private bool _isPause = false;

        public void StartPatrollling(Transform[] patroullingsPoint, Transform expectationPoint, Animator animatorUnit)
        {
            _patroullingsPoint = patroullingsPoint;
            _expectationPoint = expectationPoint;
            _animatorUnit = animatorUnit;

            if (CheckingRequiredComponents() != true)
            { 
                var AllDataPatrooling = _basePointForUnit.GetPatrolling(gameObject.GetComponent<IUnit>());
                _patroullingsPoint = AllDataPatrooling.AllPatrollingPoint;
                _expectationPoint = AllDataPatrooling.ExpectationPoint;
            }
            Patrolling();
        }

        public void AddDataPatrolling(IBasePointForUnit basePointForUnit) => _basePointForUnit = basePointForUnit;

        public void Patrolling()
        {
             var Data = GetCurrnetPoint();
             MovePosEnemy(Data.TransformPoint);
            _currnetPointPatrolling = Data.ValuePoint;
        }

        [ContextMenu("Dotween Clear()")]
        public void PausePatrolling()
        {
            _isPause = true;
            DOTween.Kill(this.gameObject, true);
        }

        private (Transform TransformPoint, int ValuePoint) GetCurrnetPoint()
        {
            if (_patroullingsPoint == null || _patroullingsPoint.Length == 0) throw new Exception("ERROR TO ARRAY NULL");

            Transform EndPointPatrolling = null;
            int ValuePoint = 0;

            if (_patroullingsPoint.Length <= _currnetPointPatrolling + 1) ValuePoint = 0;
            else ValuePoint = _currnetPointPatrolling + 1;

            EndPointPatrolling = _patroullingsPoint[ValuePoint];
            return (EndPointPatrolling, ValuePoint);
        }

        private void MovePosEnemy(Transform MovePosition)
        {
            //Рассчитать скорость за которую он должен пройти данный участок.
           this.transform.DOMove(MovePosition.position, _speedPatrulling).OnComplete(() =>
           {
               Debug.Log("Завершение передвижения к точке: " + MovePosition.position);
               if (_isPause == false)
               {
                   Patrolling();
                   _animatorUnit.SetBool("isMove", true);
               }
               else _animatorUnit.SetBool("isMove", false);
           });

            Vector3 relativePos = MovePosition.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        }

        private bool CheckingRequiredComponents()
        {
            bool isAllComponents = false;
            if (_patroullingsPoint != null && 
                _expectationPoint != null && 
                _animatorUnit != null) 
            {
                 isAllComponents = true;
            }

            return isAllComponents;
        }
    }
}
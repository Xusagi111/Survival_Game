using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Assets.Script.Patrolling
{
    public class ControllerPatrolling : MonoBehaviour
    {
        [SerializeField] private Transform[] _pointPatroullings;
        [SerializeField] private Transform _pointToExpectation;
        [SerializeField] private Animator Test_AnimatorEnemy; 
        
        private int _currnetPointPatrolling = -1;
        private float _speedPatrulling = 3f;
        private TweenerCore<Vector3, Vector3, VectorOptions> CurrentActiveTween;
        private bool _isPause = false;


        public void Start() => Patrolling();

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
            CurrentActiveTween?.Restart();
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
           CurrentActiveTween = this.transform.DOMove(MovePosition.position, _speedPatrulling).OnComplete(() =>
           {
               Debug.Log("Завершение передвижения к точке: " + MovePosition.position);
               if (_isPause == false)
               {
                   Patrolling();
                   Test_AnimatorEnemy.SetBool("isMove", true);
               }
               else Test_AnimatorEnemy.SetBool("isMove", false);
           });

            Vector3 relativePos = MovePosition.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        }
    }
}
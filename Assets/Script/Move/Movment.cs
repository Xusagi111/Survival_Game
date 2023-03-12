using UnityEngine;

namespace Assets.Script.Player.Move
{
    public abstract class Movment: MonoBehaviour
    {
        [SerializeField] protected float SpeedMove = 220;
        [SerializeField] protected float SpeedRotate = 600;
        protected float Horizontal;
        protected float Vertical;

        public abstract void GetInput();
        public abstract void Move();
    }
}
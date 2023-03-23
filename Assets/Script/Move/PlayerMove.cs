using UnityEngine;

namespace Assets.Script.Player.Move
{
    public class PlayerMove : BaseMovment
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private bool _isJoystickMove;
        [SerializeField] private Rigidbody _rigidbody;

        private StateMovment _stateMovment;
        private Animator _playerAnimator;

        private Vector3 _calculateInputPlayer;

        public bool IsJoustick
        {
            get { return _isJoystickMove; }
            set { 
                _isJoystickMove = value;
                CheckToSwitchingState();
            }
        }


        private void Awake()
        {
            _playerAnimator = GetComponent<Animator>();

            _stateMovment = new StateMovment(_joystick);
            CheckToSwitchingState();
        }

        private void Update() => GetInput();

        private void FixedUpdate()
        {
            CalculatePlayerInput();
            Move();
        }


        public override void GetInput()
        {
            var CurrentStateMove = _stateMovment.CurrentState.GetInput();
            Horizontal = CurrentStateMove.Horizontal;
            Vertical = CurrentStateMove.Vertical;
        }

        public override void Move()
        {
            if (Horizontal != 0 || Vertical != 0)
            {
                _rigidbody.velocity = _calculateInputPlayer * SpeedMove * Time.fixedDeltaTime;
                Rotate(ref _calculateInputPlayer);
                _playerAnimator.SetBool("isMove", true);
            }
            else
            {
                _playerAnimator.SetBool("isMove", false);
                _rigidbody.velocity = Vector3.zero;
            }
        }

        private void CalculatePlayerInput()
        {
            _calculateInputPlayer = new Vector3(Horizontal, 0, Vertical);
            _calculateInputPlayer.Normalize();
        }

        private void Rotate(ref Vector3 movementDirection)
        {
            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, SpeedRotate * Time.fixedDeltaTime);
            }
        }

        private void CheckToSwitchingState()
        {
            if (_isJoystickMove == true) _stateMovment.SetMoveJoustick();
            else if (_isJoystickMove == false) _stateMovment.SetMoveKeyBoard();
        }

    }
}

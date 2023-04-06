using Assets.Script.Move;
using System;
using System.Collections.Generic;

namespace Assets.Script.Player.Move
{
    public  class StateMovment
    {
        private Dictionary<Type, IGetInputPlayer> _statePlayerInput = new Dictionary<Type, IGetInputPlayer>();
        public IGetInputPlayer CurrentState { get; private set; }

        public StateMovment(Joystick joystick) 
        {
            _statePlayerInput = new Dictionary<Type, IGetInputPlayer>();
            _statePlayerInput.Add(typeof(MovePlayerKeyBoard), new MovePlayerKeyBoard());
            _statePlayerInput.Add(typeof(MovePlayerJoystick), new MovePlayerJoystick(joystick));
            _statePlayerInput.Add(typeof(PauseMove), new PauseMove());
        }

        public void SetMove(IGetInputPlayer House) => CurrentState = House;

        public IGetInputPlayer GetStateMove<T>() where T : IGetInputPlayer
        {
            var type = typeof(T);
            return _statePlayerInput[type];
        }

        public void SetMoveKeyBoard()
        {
            var State = GetStateMove<MovePlayerKeyBoard>();
             SetMove(State);
        }

        public void SetMoveJoustick()
        {
            var State = GetStateMove<MovePlayerJoystick>();
            SetMove(State);
        }

        public void SetPauseMove()
        {
            var State = GetStateMove<PauseMove>();
            SetMove(State);
        }
    }
}

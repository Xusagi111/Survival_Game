namespace Assets.Script.Player.Move
{
    //Make a joystick injection
    class MovePlayerJoystick : IGetInputPlayer
    {
        private Joystick _joystick;
        
        public MovePlayerJoystick(Joystick joystick) => _joystick = joystick;

        public (float Horizontal, float Vertical) GetInput()
        {
             return (_joystick.Horizontal, _joystick.Vertical);
        }
    }
}

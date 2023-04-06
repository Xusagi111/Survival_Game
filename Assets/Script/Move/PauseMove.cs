using Assets.Script.Player.Move;
namespace Assets.Script.Move
{
    class PauseMove : IGetInputPlayer
    {
        public (float Horizontal, float Vertical) GetInput() => (0,0);
    }
}

using System.Collections;
using UnityEngine;

namespace Assets.Script.Player.Move
{
    public class MovePlayerKeyBoard : IGetInputPlayer
    {
        public const string HORIZONTAL = "Horizontal";
        public const string VERTICAL = "Horizontal";

        public (float Horizontal, float Vertical) GetInput()
        {
            return (Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL));
        }
    }
}
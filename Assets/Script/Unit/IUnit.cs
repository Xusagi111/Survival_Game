using Assets.Script.Unit;
using UnityEngine;

namespace Assets.Script
{
    public interface IUnit
    {
        public IDamage Damage {get;}
        public Transform ThisTransform { get;}

        public IDeath Death { get; }
    }
}
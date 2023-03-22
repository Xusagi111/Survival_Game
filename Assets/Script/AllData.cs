using Assets.Script.Bullet;
using UnityEngine;

namespace Assets.Script
{
    public class AllData : MonoBehaviour
    {
        public static AllData instance;
        public AverageBullet averageBullet;


        private void Awake()
        {
            if (instance != null) Destroy(instance);
            instance = this;
        }
    }
}
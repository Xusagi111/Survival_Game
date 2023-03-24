using Assets.Script.Pool;
using UnityEditor;
using UnityEngine;

namespace Assets.Script.Bullet
{
    public class UsualBullet : BaseBullet
    {
        private void Awake() => InitTypeRes();

        public override void Move(Vector3 VelosityPos, float CountXMoveBullet = 30)
        {
            Rg.useGravity = true;
            Rg.velocity = VelosityPos * CountXMoveBullet;
            Invoke("RemovalEndTime", BulletData.RemovalTime);
            //Генерировать проджектайл, для красоты.
        }

        protected override void RemovalEndTime()
        {
            Rg.useGravity = false;
            Rg.velocity = Vector3.zero;
            LinkPool.AddResource(this);
        }

        public override void InitTypeRes()
        {
            CurrentTypeObj = typeof(UsualBullet);
        }
    }
}
﻿using System.Collections;
using UnityEngine;

namespace Assets.Script.Bullet
{
    public class AverageBullet : BaseBullet
    {
        public override void Move(Vector3 VelosityPos, float CountXMoveBullet = 30)
        {
            rg.velocity = VelosityPos * CountXMoveBullet;
            Invoke("RemovalEndTime", RemovalTime);
            //Генерировать проджектайл, для красоты.
        }

      
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IUnit>(out IUnit unit))
            {
                unit.Damage.AddDamage(DamageBullet);
                RemovalEndTime();
            }
        }

        protected override void RemovalEndTime()
        {
            Destroy(this.gameObject);
        }
    }
}
﻿using System.Collections;
using UnityEngine;

namespace Assets.Script.Bullet
{
    public class AverageBullet : BaseBullet
    {
        public override void Move(Vector3 VelosityPos)
        {
            rg.velocity = VelosityPos * 30;
            //Генерировать проджектайл, для красоты.
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<IUnit>(out IUnit unit))
            {
                unit.Damage.AddDamage(DamageBullet);
                //Перенести в пул
                Destroy(this.gameObject);
            }
        }
    }
}
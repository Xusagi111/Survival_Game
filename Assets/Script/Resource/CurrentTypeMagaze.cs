using Assets.Script.Bullet;
using UnityEngine;

namespace Assets.Script.Resource
{
    public class CurrentTypeMagaze : BaseMagazineForCartridges
    {
        [SerializeField] private MagazinTypeBulletEnum magazinTypeBulletEnum;

        private void Awake() => InitMagaze();

        private void InitMagaze()
        {
            switch (magazinTypeBulletEnum)
            {
                case MagazinTypeBulletEnum.UsualBullet:
                    TypeMagazine = typeof(UsualBullet); 
                    break;

                case MagazinTypeBulletEnum.AverageBullet:
                    TypeMagazine = typeof(AverageBullet);
                    break;

                case MagazinTypeBulletEnum.HeavyBullet:
                    TypeMagazine = typeof(HeavyBullet);
                    break;
            }
        }
    }
}
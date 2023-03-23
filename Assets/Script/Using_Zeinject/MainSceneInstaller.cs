using Assets.Script.Bullet;
using Assets.Script.Gun;
using Zenject;

namespace Assets.Script.Using_Zeinject
{
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        public AutomaticWeapons  MachineGun;
        public AverageBullet AverageBullet;
        public override void InstallBindings()
        {
            Container.Bind<AutomaticWeapons >().FromInstance(MachineGun);
            Container.Bind<AverageBullet>().FromInstance(AverageBullet);
        }
    }
}
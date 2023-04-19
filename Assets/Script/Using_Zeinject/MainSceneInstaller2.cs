using Assets.Script.Bullet;
using Assets.Script.Gun;
using Assets.Script.Inventory;
using Assets.Script.PLayer;
using Assets.Script.Pool;
using Assets.Script.UI;
using Assets.Script.Unit;
using UnityEngine;
using Zenject;

namespace Assets.Script.Using_Zeinject
{
    public class MainSceneInstaller2 : MonoInstaller<MainSceneInstaller2>
    {
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private PlayerTriggerCollision _playerInput;
        [SerializeField] private HealthUnit _healthUnit;
        [SerializeField] private ControllerTakingAnObjectFromScene _takingUiController;
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerUI _playerUI;
        [SerializeField] private HelpWithTargetingToShotInEnemy _helpComponent;

        public override void InstallBindings()
        {
            Container.Bind<PlayerInventory>().FromInstance(_playerInventory).AsSingle();
            Container.Bind<PlayerTriggerCollision>().FromInstance(_playerInput).AsSingle();
            Container.Bind<HealthUnit>().FromInstance(_healthUnit).AsSingle();
            Container.Bind<Inventory.IInventory>().FromInstance(_playerInventory).AsSingle();
            Container.Bind<ControllerTakingAnObjectFromScene>().FromInstance(_takingUiController).AsSingle();
            Container.Bind<IPoolBullet<BaseBullet>>().FromInstance(_bulletPool).AsSingle();
            Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
            Container.Bind<PlayerUI>().FromInstance(_playerUI).AsSingle();
            Container.Bind<HelpWithTargetingToShotInEnemy>().FromInstance(_helpComponent).AsSingle();
        }
    }
}
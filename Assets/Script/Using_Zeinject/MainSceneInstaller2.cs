using Assets.Script.Inventory;
using Assets.Script.UI;
using Assets.Script.Unit;
using UnityEngine;
using Zenject;

namespace Assets.Script.Using_Zeinject
{
    public class MainSceneInstaller2 : MonoInstaller<MainSceneInstaller2>
    {
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private HealthUnit _healthUnit;
        [SerializeField] private ControllerTakingAnObjectFromScene _takingUiController;

        public override void InstallBindings()
        {
            Container.Bind<PlayerInventory>().FromInstance(_playerInventory);
            Container.Bind<PlayerInput>().FromInstance(_playerInput);
            Container.Bind<HealthUnit>().FromInstance(_healthUnit);
            Container.Bind<IPlayerInventory>().FromInstance(_playerInventory);
            Container.Bind<ControllerTakingAnObjectFromScene>().FromInstance(_takingUiController);
        }
    }
}
using Assets.Script.Unit;
using UnityEngine;
using Zenject;

namespace Assets.Script.PLayer
{
    public class PlayerView : MonoBehaviour, IUnit
    {
        private PlayerInventory _playerInventory;
        private PlayerInput _playerInput;
        private HealthUnit _healthUnit;

        public IDamage Damage => _healthUnit;

        [Inject]
        private void Constructor(PlayerInventory playerInventory, PlayerInput playerInput, HealthUnit healthUnit)
        {
            _playerInventory = playerInventory;
            _playerInput = playerInput;
            _healthUnit = healthUnit;
        }

        //private void Awake() => _playerInput.AddInventoryPlayer(_playerInventory);
    }
}
using Assets.Script.Unit;
using UnityEngine;

namespace Assets.Script.PLayer
{
    //TODO ZEING
    public class PlayerView : MonoBehaviour, IUnit
    {
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private HealthUnit _healthUnit;

        public IDamage Damage => _healthUnit;

        private void Start()
        {
            _playerInput.AddInventoryPlayer(_playerInventory);
        }
    }
}
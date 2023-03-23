using Assets.Script.Inventory;
using Assets.Script.Unit;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Script.PLayer
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Image _hpBar;
        private HealthUnit _playerHealf;
        private PlayerView _playerView;
        private IPlayerInventory _playerInventory;

        [Inject]
        private void Constructor(IPlayerInventory playerInventory, PlayerView playerView, HealthUnit healthUnit)
        {
            _playerInventory = playerInventory;
            _playerView = playerView;
            _playerHealf = healthUnit;
        }

        private void Awake()
        {
            _playerHealf.EventUpdateHealf += ChangesToHpBar;
        }

        private void OnDestroy()
        {
            _playerHealf.EventUpdateHealf -= ChangesToHpBar;
        }

        public void ChangesToHpBar()
        {
            _hpBar.fillAmount = _playerHealf.Health / _playerHealf.MaxHealth;
        }
    }
}
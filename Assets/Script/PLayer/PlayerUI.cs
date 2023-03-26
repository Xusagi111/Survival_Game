using Assets.Script.Inventory;
using Assets.Script.Unit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Script.PLayer
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Image _hpBar;
        [SerializeField] private TextMeshProUGUI CurrentCartridgesT;
        private HealthUnit _playerHealf;
        private PlayerView _playerView;
        private IInventory _playerInventory;

        [Inject]
        private void Constructor(Inventory.IInventory playerInventory, PlayerView playerView, HealthUnit healthUnit)
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

        public void ChangesToBullet(int CountBullet, int MaxMagazineBullet)
        {
            CurrentCartridgesT.text = $"{CountBullet} / {MaxMagazineBullet}";
        }
    }
}
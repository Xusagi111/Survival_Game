using Assets.Script.Gun;
using Assets.Script.Unit;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Script.PLayer
{
    public class PlayerView : MonoBehaviour, IUnit
    {
        public  UnityEvent<int, int> EventUpdateCartridges;
        private PlayerInventory _playerInventory;
        private PlayerTriggerCollision _playerInput;
        private PlayerUI _playerUI;
        private HealthUnit _healthUnit;
        public BaseWeapon ActiveWeapon { get; private set; }
        [field: SerializeField] public Transform ParentToWeapon { get; set; }

        public IDamage Damage => _healthUnit;

        public Transform ThisTransform { get => this.transform; }

        [Inject]
        private void Constructor(PlayerInventory playerInventory, PlayerTriggerCollision playerInput, HealthUnit healthUnit, PlayerUI playerUI)
        {
            _playerInventory = playerInventory;
            _playerInput = playerInput;
            _healthUnit = healthUnit;
            _playerUI = playerUI;
        }


        [ContextMenu("Invoke To Scene")]
        public void AttackEvent()
        {
            if (ActiveWeapon?.isActiveWeapon == true) ActiveWeapon.Attack();
        }

        public void AddWeapon(BaseWeapon ActiveWeapon)
        {
            this.ActiveWeapon = ActiveWeapon;
            ActiveWeapon.DisableComponent();
            Invoke("ChangesToPosWeapons", 1f);
        }

        private void ChangesToPosWeapons()
        {
            ActiveWeapon.isActiveWeapon = true;
            ActiveWeapon.isActiveWeapon = true;
            ActiveWeapon.gameObject.transform.parent = ParentToWeapon;
            ActiveWeapon.transform.position = Vector3.zero;
            ActiveWeapon.transform.localPosition = Vector3.zero;
            ActiveWeapon.transform.localEulerAngles = Vector3.zero;
            ActiveWeapon.gameObject.SetActive(true);

            if (ActiveWeapon is ShootingWeapon shooting)
            {
                AddEvent(shooting);
                shooting.UsingWeapon(_playerInventory);
            }
        }

        private void UpdateCartridges(int CountBullet, int MaxMagazineBullet) => _playerUI.ChangesToBullet(CountBullet, MaxMagazineBullet);

        public void AddEvent(ShootingWeapon shooting) 
        {
            EventUpdateCartridges = shooting.EventUpdateCartridges;
            EventUpdateCartridges?.RemoveAllListeners();
            EventUpdateCartridges?.AddListener(UpdateCartridges);
        }
    }
}
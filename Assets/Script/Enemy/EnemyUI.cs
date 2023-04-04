using Assets.Script.Unit;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Enemy
{
    public class EnemyUI : MonoBehaviour
    {
        [SerializeField] private Image _hpBar;
        [SerializeField] private HealthUnit _healthUnit;

        private void Awake()
        {
            _healthUnit.EventUpdateHealf += ChangesToHpBar;
        }

        private void OnDestroy()
        {
            _healthUnit.EventUpdateHealf -= ChangesToHpBar;
        }

        public void ChangesToHpBar()
        {
            _hpBar.fillAmount = _healthUnit.Health / _healthUnit.MaxHealth;
        }
    }
}
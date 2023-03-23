using Assets.Script.PLayer;
using Assets.Script.Unit;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Enemy
{
    public class EnemyUI : MonoBehaviour
    {
        [SerializeField] private Image _hpBar;
        [SerializeField] private HealthUnit _healf;

        private void Awake()
        {
            _healf.EventUpdateHealf += ChangesToHpBar;
        }

        private void OnDestroy()
        {
            _healf.EventUpdateHealf -= ChangesToHpBar;
        }

        public void ChangesToHpBar()
        {
            _hpBar.fillAmount = _healf.Health / _healf.MaxHealth;
        }
    }
}
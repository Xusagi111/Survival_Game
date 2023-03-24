using UnityEngine;

namespace Assets.Script.Bullet
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/BulletData", order = 1)]
    public class BullletData : ScriptableObject
    {
        [SerializeField] private float _damageBullet;
        [SerializeField] private float _removalTime = 2.5f;
       
        public float DamageBullet => _damageBullet;
        public float RemovalTime => _removalTime;
    }
}
using UnityEditor;
using UnityEngine;

namespace Assets.Script.Resource
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/UIDataResource", order = 1)]
    public class UIDataResource : ScriptableObject
    {
        [SerializeField] private Sprite _iconImage;
        public Sprite IconImage => _iconImage;
    }
}
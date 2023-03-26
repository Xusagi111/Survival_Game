using UnityEditor;
using UnityEngine;

namespace Assets.Script.Resource
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/UIDataResource", order = 1)]
    public class UIDataResource : ScriptableObject
    {
        [SerializeField] private Sprite _iconImage;
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private bool _isRotate;

        public int Id => 0;

        public int Width => _width;

        public int Height => _height;

        public bool IsRotate { get => _isRotate; set => _isRotate = value; }
        public Sprite IconImage => _iconImage;

       // public IVariableInventoryAsset ImageAsset => throw new System.NotImplementedException();
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Pools
{
    public class BasePool<T> : MonoBehaviour where T : Component
    {
        List<T> ListUnitComponents;
        [SerializeField] private T PrefabObj;
        [SerializeField] private int CountCreateBlocks = 10;
        [SerializeField] private bool isUiGameobject;

        private void Start()
        {
            ListUnitComponents = new List<T>(CountCreateBlocks);
            CreateFixedCountComponent(CountCreateBlocks);
        }

        public T UnitComponent
        {
            get
            {
                if (ListUnitComponents.Count != 0)
                {
                    T GetBlock = ListUnitComponents[0];
                    ListUnitComponents.Remove(GetBlock);
                    return GetBlock;
                }
                else
                {
                    CreateFixedCountComponent(5);
                    T GetBlock = ListUnitComponents[0];
                    ListUnitComponents.Remove(GetBlock);
                    return GetBlock;
                }
            }
            set
            {
                DisableGetComponent(value);
                ListUnitComponents.Add(value);
            }
        }

        public T ActivatedComponent(Transform position, T Unit) 
        {
            Unit.transform.position = position.position;
            Unit.gameObject.SetActive(true);
            return Unit;
        }

        private void CreateFixedCountComponent(int CountCreate)
        {
            for (int i = 0; i < CountCreateBlocks; i++)
            {
                T CreateElement = Instantiate(PrefabObj, Vector3.one, Quaternion.identity, transform);

                ((Component)CreateElement).gameObject.SetActive(false);

                ListUnitComponents.Add(CreateElement);
            }
        }

        private void DisableGetComponent(T UnitComponent)
        {
            UnitComponent.gameObject.SetActive(false);
            UnitComponent.transform.SetParent(this.transform);
            UnitComponent.gameObject.transform.position = Vector3.zero;

            if (isUiGameobject == true)
            {
                UnitComponent.transform.localScale = UnitComponent.transform.localScale ;
            }
        }
    }
}
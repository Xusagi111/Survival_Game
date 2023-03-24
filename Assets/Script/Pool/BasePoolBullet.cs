using Assets.Script.Bullet;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Pool
{
    public class BasePoolBullet<T> : MonoBehaviour where T : BaseBullet
    {
        List<T> ListUnitComponents;
        [SerializeField] private T[] PrefabsCreateExemplar;
        [SerializeField] private int CountCreateIteration = 10;
        [SerializeField] private bool isUiGameobject;

        private void Start()
        {
            ListUnitComponents = new List<T>(CountCreateIteration);
            foreach (var item in PrefabsCreateExemplar)
            {
                item.InitTypeRes();
                CreateToRequiredResourceType(item.CurrentTypeObj);
            }
        }

        public void AddResource(T value)
        {
            DisableGetComponent(value);
            ListUnitComponents.Add(value);
        }

        public T GetResource(Type TypeGetRes)
        {
            T ItemRes = null;
            for (int i = 0; i < ListUnitComponents.Count; i++)
            {
                if (TypeGetRes == ListUnitComponents[i].CurrentTypeObj)
                {
                    ItemRes = ListUnitComponents[i];
                    break;
                }
            }
            if (ItemRes == null) ItemRes = CreateToRequiredResourceType(TypeGetRes);
            ListUnitComponents.Remove(ItemRes);
            return ItemRes;
        }

        public T ActivatedComponent(Transform position, T Unit)
        {
            Unit.transform.position = position.position;
            Unit.gameObject.SetActive(true);
            return Unit;
        }

        private void DisableGetComponent(T UnitComponent)
        {
            UnitComponent.gameObject.SetActive(false);
            UnitComponent.transform.SetParent(this.transform);
            UnitComponent.gameObject.transform.position = Vector3.zero;

            if (isUiGameobject == true)
            {
                UnitComponent.transform.localScale = UnitComponent.transform.localScale;
            }
        }

        private T GetPrefabSpecificType(Type TypeExemplar)
        {
            for (int i = 0; i < PrefabsCreateExemplar.Length; i++)
            {
                T Item = PrefabsCreateExemplar[i];
                if (Item.CurrentTypeObj == TypeExemplar)
                {
                    return Item;
                }
            }
            return null;
        }

        private T CreateToRequiredResourceType(Type TypeRes)
        {
            T CurrentReturnedRes = null;
            T PrefabRes = GetPrefabSpecificType(TypeRes);
            for (int i = 0; i < 10; i++)
            {
                T CreateElement = Instantiate(PrefabRes, Vector3.one, Quaternion.identity, transform);

                CreateElement.gameObject.SetActive(false);
                ListUnitComponents.Add(CreateElement);
                CreateElement.Construct((IPoolBullet<BaseBullet>)(this));

                if (CreateElement != null) CurrentReturnedRes = CreateElement;
            }

            return CurrentReturnedRes;
        }
    }
}
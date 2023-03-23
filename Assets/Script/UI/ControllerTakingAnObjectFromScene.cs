using Assets.Script.PLayer;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.UI
{
    public class ControllerTakingAnObjectFromScene : MonoBehaviour
    {
        [SerializeField] private Button TakeObjectB;
        [SerializeField] private List<PlayerCollisiоn> list = new List<PlayerCollisiоn>();

        public void SetActiveEvent(bool isState, PlayerCollisiоn playerCollisiоn)
        {
            TakeObjectB.gameObject.SetActive(isState);
            if (isState == true) AddEventButton(playerCollisiоn);
            else RemoveEventButton(playerCollisiоn);

        }

        private void AddEventButton(PlayerCollisiоn playerCollisiоn)
        {
            list.Add(playerCollisiоn);
            TakeObjectB.onClick.AddListener(() =>
            {
                playerCollisiоn.Collision();
                SetActiveEvent(false, playerCollisiоn);
            });
        }

        private void RemoveEventButton(PlayerCollisiоn playerCollisiоn)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var Item = list[i];
                if (Item == playerCollisiоn)
                {
                    TakeObjectB.onClick.RemoveListener(() => playerCollisiоn.Collision());
                    Item.ResetModel();
                    list.Remove(Item);
                    break;
                }
            }
        }
    }
}
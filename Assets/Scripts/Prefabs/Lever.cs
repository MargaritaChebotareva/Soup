using Assets.Scripts.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Prefabs
{
    public class Lever : MonoBehaviour, IPointerClickHandler
    {
        private LeverController leverController;
        public void Init(LeverController leverController)
        {
            this.leverController = leverController;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            leverController.ClickOnLever();
        }
    }
}
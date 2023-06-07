using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public class PlayerPopup : Popup
    {
        [Header("Widgets")] 
        [SerializeField] private List<Widget> widgets;

        [SerializeField] private Button closeButton;

        [Button]
        protected override void OnShow()
        {
            widgets.ForEach((widget => widget.OnShow()));

            closeButton.onClick.AddListener(OnCloseClicked);
        }

        protected override void OnHide()
        {
            widgets.ForEach((widget => widget.OnHide()));
          
            closeButton.onClick.RemoveListener(OnCloseClicked);
        }

        private void OnCloseClicked()
        {
            RequestClose();
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.UI.Windows
{
    public class MainMenuWindow : WindowBase
    {
        [SerializeField] Button _buttonStart;

        public event Action ButtonClicked;

        private void OnEnable() =>
            _buttonStart.onClick.AddListener(OnButtonMainMenuClicked);

        private void OnDisable() =>
            _buttonStart.onClick.RemoveListener(OnButtonMainMenuClicked);

        private void OnButtonMainMenuClicked()
        {
            ButtonClicked?.Invoke();
        }
    }
}

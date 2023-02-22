using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.UI.Windows
{
    public class GameOverWindow : WindowBase
    {
        [SerializeField] Button _buttonMainMenu;

        public event Action ButtonClicked;

        private void OnEnable() =>
            _buttonMainMenu.onClick.AddListener(OnButtonMainMenuClicked);

        private void OnDisable() =>
            _buttonMainMenu.onClick.RemoveListener(OnButtonMainMenuClicked);

        private void OnButtonMainMenuClicked()
        {
            ButtonClicked?.Invoke();
        }
    }
}

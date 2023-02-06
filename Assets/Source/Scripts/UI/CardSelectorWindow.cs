using System;
using UnityEngine;

namespace Assets.Source.Scripts.UI
{
    public class CardSelectorWindow : WindowBase
    {
        [SerializeField] private Transform _container;

        public event Action<string> CardSelected;

        public void AddCard(AbilityCard card)
        {
            card.gameObject.transform.SetParent(_container);
            card.Selected += OnCardSelected;
        }

        private void OnCardSelected(string id)
        {
            CardSelected?.Invoke(id);
        }
    }
}

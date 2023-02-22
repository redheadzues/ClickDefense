using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.UI.Windows
{
    public class CardSelectorWindow : WindowBase
    {
        [SerializeField] private Transform _container;

        private List<AbilityCard> _cards = new List<AbilityCard>();

        public event Action<string> CardSelected;

        private void OnDisable() =>
            _cards.ForEach(x => x.Selected -= OnCardSelected);

        public void AddCard(AbilityCard card)
        {
            card.gameObject.transform.SetParent(_container);
            card.Selected += OnCardSelected;
            _cards.Add(card);
        }

        private void OnCardSelected(string id) =>
            CardSelected?.Invoke(id);
    }
}

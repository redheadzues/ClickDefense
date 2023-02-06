using Assets.Source.Scripts.AbilitiesSystem.Abilities;
using Assets.Source.Scripts.AbilitiesSystem.Factories;
using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.StaticData;
using Assets.Source.Scripts.Player;
using Assets.Source.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Shops
{
    public class PlayerAbilityRewarder
    {
        private readonly PlayerAbilitiesStaticData _passiveAbilitiesData;
        private readonly IAbilityFactory _abilityFactory;
        private readonly AbilityContainer _container;
        private IUIFactory _uiFactory;
        private CardSelectorWindow _cardSelector;

        public PlayerAbilityRewarder(
            PlayerAbilitiesStaticData passiveAbilitiesData,
            IAbilityFactory abilityFactory,
            AbilityContainer container,
            Vawe vawe,
            IUIFactory uiFactory)
        {
            _passiveAbilitiesData = passiveAbilitiesData;
            _abilityFactory = abilityFactory;
            _container = container;
            _uiFactory = uiFactory;
            vawe.Finished += OnVaweFinished;
        }

        private void OnVaweFinished()
        {
            ShowAbilityCard();
        }

        private void ShowAbilityCard()
        {
            OpenCardSelector();
            AddCardsInSelector();
        }

        private void OpenCardSelector()
        {
            _cardSelector = _uiFactory.CreateWindow<CardSelectorWindow>(WindowId.CardSelector);
            _cardSelector.CardSelected += OnCardSelected;
        }

        private void AddCardsInSelector()
        {
            List<AbilityStaticData> availableAbility = GetAvaliableAbility();

            foreach (AbilityStaticData ability in availableAbility)
            {
                AbilityCard card = GetConstructedCard(ability);
                _cardSelector.AddCard(card);
            }
        }

        private AbilityCard GetConstructedCard(AbilityStaticData ability)
        {
            AbilityCard card = _uiFactory.CreateUIElement(AssetPath.AbilityCard).GetComponent<AbilityCard>();
            card.SetData(ability.Icon, ability.Name, ability.Description, ability.Id);

            return card;
        }

        private List<AbilityStaticData> GetAvaliableAbility()
        {
            return _passiveAbilitiesData.AbilitiesData;
        }

        private void OnCardSelected(string id)
        {
            AddAbilityToPlayer(id);
            DestroySelector();
        }

        private void AddAbilityToPlayer(string Id)
        {
            Ability ability = _abilityFactory.Create(Id);
            _container.AddAbility(ability);
        }

        private void DestroySelector()
        {
            _cardSelector.CardSelected -= AddAbilityToPlayer;
            _cardSelector.Destroy();
        }
    }
}

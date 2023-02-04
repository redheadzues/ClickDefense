using Assets.Source.Scripts.AbilitiesSystem.Abilities;
using Assets.Source.Scripts.AbilitiesSystem.Factories;
using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.Infrustructure.StaticData;
using Assets.Source.Scripts.Player;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Shops
{
    public class PlayerAbilityRewarder
    {
        private readonly PlayerAbilitiesStaticData _passiveAbilitiesData;
        private readonly IAbilityFactory _abilityFactory;
        private readonly AbilityContainer _container;

        public PlayerAbilityRewarder(
            PlayerAbilitiesStaticData passiveAbilitiesData,
            IAbilityFactory abilityFactory,
            AbilityContainer container,
            Vawe vawe)
        {
            _passiveAbilitiesData = passiveAbilitiesData;
            _abilityFactory = abilityFactory;
            _container = container;
            //vawe.Finished += OnVaweFinished;
        }

        public List<AbilityStaticData> GetAvaliableAbility()
        {
            return _passiveAbilitiesData.AbilitiesData;
        }

        public void AddAbilityToPlayer(string Id)
        {
            Ability ability = _abilityFactory.Create(Id);
            _container.AddAbility(ability); 
        }
    }
}

using Assets.Source.Scripts.AbilitiesSystem.Abilities;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Player
{
    public class AbilityContainer
    {
        private List<Ability> _abilities = new List<Ability>();

        public IReadOnlyList<Ability> List => _abilities;

        public void AddAbility(Ability ability)
        {
            _abilities.Add(ability);
        }
    }
}

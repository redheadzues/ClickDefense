using Assets.Source.Scripts.AbilitiesSystem;
using Assets.Source.Scripts.Enemies;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Player;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Player
{
    public class DamageDealer
    {
        private readonly DamageCalculator _damageCalculator;

        public DamageDealer(IClickInformer clickInformer, DamageCalculator damageCalculator)
        {
            _damageCalculator = damageCalculator;

            clickInformer.Clicked += OnClicked;
        }

        private void OnClicked(IDamageable damageable)
        {
            damageable.TakeDamage(_damageCalculator.GetValue());
        }
    }

    public class AbilityApplyer
    {
        public void OnTargetGetted(IAbilityTarget target)
        {
            
        }
    }

    public class PlayerAbilityContainer
    {
        private List<Ability> _abilities = new List<Ability>();

        public IReadOnlyList<Ability> List => _abilities;

        public void AddAbility(Ability ability)
        {
            _abilities.Add(ability);
        }
    }
}

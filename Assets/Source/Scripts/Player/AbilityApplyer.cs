using Assets.Source.Scripts.AbilitiesSystem;
using Assets.Source.Scripts.AbilitiesSystem.Abilities;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;

namespace Assets.Source.Scripts.Player
{
    public class AbilityApplyer
    {
        private readonly AbilityContainer _container;

        public AbilityApplyer(AbilityContainer container, IClickInformer clickInformer)
        {
            _container = container;
            clickInformer.AbilityTargetGeted += OnTargetGetted;
        }

        public void OnTargetGetted(IAbilityTarget target)
        {
            if(_container.List.Count > 0)
            {
                foreach (Ability ability in _container.List)
                    ability.Activate(target);
            }
        }
    }
}

using Assets.Source.Scripts.AbilitiesSystem.StaticData;

namespace Assets.Source.Scripts.AbilitiesSystem.Abilities
{
    public class SingleAbility : Ability
    {
        public SingleAbility(AbilityStaticData data) : base(data) { }

        public override void Activate(IAbilityTarget target)
        {
            GiveEffect(target);
        }
    }
}

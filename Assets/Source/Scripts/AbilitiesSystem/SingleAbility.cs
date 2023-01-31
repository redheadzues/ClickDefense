using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System.Collections.Generic;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class SingleAbility : Ability
    {
        public SingleAbility(List<GamePlayEffectStaticData> effects) : base(effects){}

        public override void Activate(IAbilityTarget target)
        {
            GiveEffect(target);
        }
    }
}

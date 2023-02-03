using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Abilities
{
    public class AreaAbility : Ability
    {
        private readonly float _radius;

        public AreaAbility(AbilityStaticData data) : base(data)
        {
            _radius = data.Area;
        }


        public override void Activate(IAbilityTarget target)
        {
            GiveEffect(target);
            FindTargets(target.Position, _radius);
            ApplyEffectsOnTargets();
        }

        private void ApplyEffectsOnTargets()
        {
            foreach (Collider collider in _hits)
            {
                if (collider != null && collider.TryGetComponent(out IAbilityTarget target))
                    GiveEffect(target);
            }
        }
    }
}

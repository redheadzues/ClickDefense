using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class AreaAbility : Ability
    {
        private readonly float _radius;

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
                if (collider.TryGetComponent(out IAbilityTarget target))
                    GiveEffect(target);
            }
        }
    }
}

using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class ChainAbility : Ability
    {
        private readonly float _distance;
        private readonly int _maxCountTargets;

        private int _numberOfTargetsRecived;

        public override void Activate(IAbilityTarget target)
        {
            GiveEffect(target);
            FindTargets(target.Position, _distance);
            MoveToNextTarget();
        }

        private void MoveToNextTarget()
        {
            IAbilityTarget nextTarget = GetNextTarget();

            if((_numberOfTargetsRecived < _maxCountTargets) && (nextTarget != null))
            {
                _numberOfTargetsRecived++;
                Activate(nextTarget);
            }
            else
                Deactivate();
        }

        private IAbilityTarget GetNextTarget()
        {
            foreach (Collider collider in _hits)
            {
                if (collider.TryGetComponent(out IAbilityTarget target))
                {
                    if (CheckTargetForApply(target) == true)
                        return target;
                }
            }

            return null;
        }

        private void Deactivate()
        {
            _numberOfTargetsRecived = 0;
        }
    }
}

using Assets.Source.Scripts.AbilitiesSystem.Components;
using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Abilities
{
    public class ChainAbility : Ability
    {
        private readonly float _distance;
        private readonly int _maxCountTargets = 2;
        private readonly GameObject _projectilePrefab;

        private int _numberOfTargetsRecived;
        private ProjectileComponent _projectile;

        public ChainAbility(AbilityStaticData data) : base(data)
        {
            _distance = data.Area;
            _projectilePrefab = data.projectilePrefab;
        }

        public override void Activate(IAbilityTarget target)
        {
            CreateProjectile(target);
            GiveEffect(target);
            FindTargets(target.Position, _distance);
            MoveToNextTarget(target);

        }

        private void CreateProjectile(IAbilityTarget target)
        {
            if (_projectile == null)
            {
                GameObject projectile = UnityEngine.Object.Instantiate(_projectilePrefab, target.Position, Quaternion.identity);
                _projectile = projectile.AddComponent<ProjectileComponent>();
                _projectile.Initialize(this);
            }
        }

        private void MoveToNextTarget(IAbilityTarget lastTarget)
        {
            IAbilityTarget nextTarget = GetNextTarget(lastTarget);

            if (_numberOfTargetsRecived < _maxCountTargets && nextTarget != null)
            {
                _numberOfTargetsRecived++;
                _projectile.SetTarget(nextTarget);
            }
            else
                Deactivate();
        }

        private IAbilityTarget GetNextTarget(IAbilityTarget lastTarget)
        {
            foreach (Collider collider in _hits)
            {
                if (collider != null && collider.TryGetComponent(out IAbilityTarget target))
                {
                    if (target != lastTarget)
                    {
                        if (CheckTargetForApply(target) == true)
                            return target;
                    }
                }
            }

            return null;
        }

        private void Deactivate()
        {
            _numberOfTargetsRecived = 0;
            GameObject.Destroy(_projectile.gameObject);
        }
    }
}

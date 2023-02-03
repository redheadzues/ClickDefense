using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.Infrustructure;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class ChainAbility : Ability
    {
        private readonly float _distance;
        private readonly int _maxCountTargets = 2;
        private readonly GameObject _projectilePrefab;
        private readonly ICoroutineRunner _coroutineRunner;

        private int _numberOfTargetsRecived;
        private ProjectileComponent _projectile;

        public ChainAbility(AbilityStaticData data, ICoroutineRunner coroutineRunner) : base(data) 
        {
            _distance = data.Area;
            _projectilePrefab = data.projectilePrefab;
            _coroutineRunner = coroutineRunner;
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
            if(_projectile == null)
            {
                GameObject projectile = GameObject.Instantiate(_projectilePrefab, target.Position, Quaternion.identity);
                 _projectile =  projectile.AddComponent<ProjectileComponent>();
                _projectile.Initialize(this);
            }            
        }

        private void MoveToNextTarget(IAbilityTarget lastTarget)
        {
            IAbilityTarget nextTarget = GetNextTarget(lastTarget);

            if ((_numberOfTargetsRecived < _maxCountTargets) && (nextTarget != null))
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
                    if(target != lastTarget)
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

    public class ProjectileComponent : MonoBehaviour
    {
        private Ability _ability;
        private IAbilityTarget _currentTarget;
        private Coroutine _coroutine;

        public void Initialize(Ability ability)
        {
            _ability = ability;
        }

        public void SetTarget(IAbilityTarget nextTarget)
        {
            _currentTarget = nextTarget;
            StartMove();
        }

        private void StartMove()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(OnMove(_currentTarget));
        }

        private void Move(Vector3 target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 20 * Time.deltaTime);
        }

        private IEnumerator OnMove(IAbilityTarget target)
        {
            float distance = float.PositiveInfinity;

            while (distance > 0.1f)
            {
                distance = Vector3.Distance(transform.position, target.Position);
                Move(target.Position);
                yield return null;
            }

            _ability.Activate(_currentTarget);
        }
    }
}

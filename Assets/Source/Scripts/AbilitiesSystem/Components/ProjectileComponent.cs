using Assets.Source.Scripts.AbilitiesSystem.Abilities;
using System.Collections;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Components
{
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

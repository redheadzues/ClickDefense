using Assets.Source.Scripts.BehaviourTreeAI;
using UnityEngine;

namespace Assets.Source.Scripts.GameAI
{
    public class EnemySeeker : ActionNode
    {
        [SerializeField] private Transform _selfTransform;
        [SerializeField] private float _searchRadius;

        private Collider[] _enemies;

        public override State OnEvaluate(float time)
        {
            _enemies = new Collider[3];

            Physics.OverlapSphereNonAlloc(_selfTransform.position, _searchRadius, _enemies);

            return _enemies.Length > 0 ? State.SUCCESS : State.FAILURE;
        }
    }
}

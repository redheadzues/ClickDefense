using Assets.Source.Scripts.BehaviourTreeAI;
using UnityEngine;

namespace Assets.Source.Scripts.GameAI
{
    public class EnemySeeker : ActionNode
    {
        [Shared] public Transform SelfTransform;
        [Shared] public float SearchRadius;

        private Collider[] _enemies;

        public override State OnEvaluate(float time)
        {
            _enemies = new Collider[3];

            Physics.OverlapSphereNonAlloc(SelfTransform.position, SearchRadius, _enemies);

            return _enemies.Length > 0 ? State.SUCCESS : State.FAILURE;
        }
    }
}

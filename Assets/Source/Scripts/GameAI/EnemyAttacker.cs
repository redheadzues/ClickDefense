using Assets.Source.Scripts.BehaviourTreeAI;
using UnityEngine;

namespace Assets.Source.Scripts.GameAI
{
    public class EnemyAttacker : ActionNode
    {
        [Shared] public Transform SelfTransform;
        [Shared] public Animator Animator;

        private Transform _target;
        private float _attackDistance;

        public override State OnEvaluate(float time)
        {
            if (Vector3.Distance(SelfTransform.position, _target.position) <= _attackDistance)
            {
                //_animator
                return State.RUNNING;
            }
            else
                return State.FAILURE;

        }
    }
}

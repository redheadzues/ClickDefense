using Assets.Source.Scripts.BehaviourTreeAI;
using UnityEngine;

namespace Assets.Source.Scripts.GameAI
{
    public class MoverToTarget : ActionNode
    {
        [Shared] public Transform SelfTransform;

        private Vector3 _targetPosition;
        private float _speed;
        private float _requiredDistance;

        public override State OnEvaluate(float time)
        {
            MoveToTarget(time);

            return Vector3.Distance(SelfTransform.position, _targetPosition) > _requiredDistance 
                ? State.RUNNING : State.SUCCESS;
        }

        private void MoveToTarget(float deltaTime)
        {
            SelfTransform.position = Vector3.MoveTowards(SelfTransform.position, _targetPosition, _speed * deltaTime);
        }
    }
}


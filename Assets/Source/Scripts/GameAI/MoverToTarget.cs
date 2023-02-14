using Assets.Source.Scripts.BehaviourTreeAI;
using UnityEngine;

namespace Assets.Source.Scripts.GameAI
{
    public class MoverToTarget : ActionNode
    {
        [SerializeField] private Transform _selfTransform;

        private Vector3 _targetPosition;
        private float _speed;
        private float _requiredDistance;

        public override State OnEvaluate(float time)
        {
            MoveToTarget(time);

            return Vector3.Distance(_selfTransform.position, _targetPosition) > _requiredDistance 
                ? State.RUNNING : State.SUCCESS;
        }

        private void MoveToTarget(float deltaTime)
        {
            _selfTransform.position = Vector3.MoveTowards(_selfTransform.position, _targetPosition, _speed * deltaTime);
        }
    }
}


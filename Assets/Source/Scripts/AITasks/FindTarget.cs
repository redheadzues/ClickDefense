using Assets.Source.Scripts.AbilitiesSystem.Components;
using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Scripts.AITasks
{
    public class FindTarget : Action
    {
        public SharedTransform Target;

        private Collider[] targets = new Collider[10];

        public override TaskStatus OnUpdate()
        {
            return TryFindEnemy() ? TaskStatus.Success : TaskStatus.Failure;
        }

        private bool TryFindEnemy()
        {
            Physics.OverlapSphereNonAlloc(transform.position, 20, targets);

            float minDistance = float.MaxValue;
            Transform currentTarget = null;

            foreach (Collider target in targets)
            {
                if (target != null && target.TryGetComponent(out AbilityTargetComponent tagsContainer))
                    if (tagsContainer.Tags.Contains(AbilityTag.Enemy))
                    {
                        float distanceToTarget = Vector3.Distance(tagsContainer.transform.position, transform.position);

                        if (distanceToTarget < minDistance)
                        {
                            minDistance = distanceToTarget;
                            currentTarget = tagsContainer.transform;
                        }
                    }
            }

            if (currentTarget != null)
            {
                Target.Value = currentTarget;
                return true;
            }

            return false;
        }
    }
}

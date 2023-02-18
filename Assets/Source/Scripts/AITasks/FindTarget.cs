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

            foreach (Collider target in targets)
            {
                if (target != null && target.TryGetComponent(out AbilityTargetComponent tagsContainer))
                    if (tagsContainer.Tags.Contains(AbilityTag.Enemy))
                    {
                        Target.Value = tagsContainer.transform;
                        return true;
                    }
            }

            return false;
        }
    }
}

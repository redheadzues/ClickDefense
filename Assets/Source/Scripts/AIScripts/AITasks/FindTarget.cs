using Assets.Source.Scripts.AbilitiesSystem.Components;
using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.CharactersComponent;
using BehaviorDesigner.Runtime.Tasks;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Scripts.AIScripts.AITasks
{
    public class FindTarget : Action
    {
        public SharedContext Context;

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
                {
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
            }

            if (currentTarget != null)
            {
                Context.Value.Target = currentTarget;
                Context.Value.TargetHealth = currentTarget.GetComponent<IDamageable>();
                return true;
            }

            return false;
        }
    }
}

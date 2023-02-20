using Assets.Source.Scripts.Enemies;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace Assets.Source.Scripts.AITasks
{
    public class DefineDestination : Action
    {
        public SharedVector3 Destination;

        private IEnemy _enemy;

        public override void OnStart()
        {
            if(_enemy == null)
                _enemy = GetComponent<Enemy>();
        }

        public override TaskStatus OnUpdate()
        {
            if(_enemy != null)
                Destination.Value = new Vector3(_enemy.TargetPointX, transform.position.y, transform.position.z);

            return TaskStatus.Success;
        }
    }
}


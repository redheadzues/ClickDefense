using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class WaitNode : ActionNode
    {
        public float duration = 1;
        float startTime;

        public override void OnStart()
        {
            startTime = Time.time;
        }

        public override void OnStop()
        {
            
        }

        public override State OnUpdate()
        {
            if (Time.time - startTime > duration)
                return State.SUCCESS;
            else
                return State.RUNNING;
        }
    }
}

using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class WaitNode : ActionNode
    {
        public float duration = 1;
        private float time;

        public override void OnStart()
        {
            time = 0;
        }

        public override State OnEvaluate()
        {
            time += Time.deltaTime;

            if (time > duration)
                return State.SUCCESS;
            else
                return State.RUNNING;
        }
    }
}

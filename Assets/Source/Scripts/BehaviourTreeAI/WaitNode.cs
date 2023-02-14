namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class WaitNode : ActionNode
    {
        public float duration = 1;
        private float _passedTime;

        public override void OnStart()
        {
            _passedTime = 0;
        }

        public override State OnEvaluate(float time)
        {
            _passedTime += time;

            if (_passedTime > duration)
                return State.SUCCESS;
            else
                return State.RUNNING;
        }
    }
}

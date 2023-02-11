using System;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class SequencerNode : CompositeNode
    {
        int number;

        public override void OnStart()
        {
            number = 0;
        }

        public override void OnStop()
        {

        }

        public override State OnUpdate()
        {
            var child = Children[number];

            switch (child.Update())
            {
                case State.RUNNING:
                    return State.RUNNING;
                case State.FAILURE:
                    return State.FAILURE;
                case State.SUCCESS:
                    number++;
                    break;
            }


            return number == Children.Count ? State.SUCCESS : State.RUNNING;
        }
    }
}
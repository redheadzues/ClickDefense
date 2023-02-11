using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public abstract class Node : ScriptableObject
    {
        public State State = State.RUNNING;
        public bool Started = false;

        public State Update()
        {
            if (Started == false)
            {
                OnStart();
                Started = true;
            }

            State = OnUpdate();

            if (State == State.FAILURE || State == State.SUCCESS)
            {
                OnStop();
                Started = false;
            }

            return State;
        }

        public abstract void OnStart();
        public abstract void OnStop();
        public abstract State OnUpdate();



    }
}

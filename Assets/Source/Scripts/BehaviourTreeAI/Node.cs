using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public abstract partial class Node : ScriptableObject
    {
        public State state  = State.RUNNING;
        public bool Started = false;

        public State Update()
        {
            if (Started == false)
            {
                OnStart();
                Started = true;
            }

            state = OnUpdate();

            if (state == State.FAILURE || state == State.SUCCESS)
            {
                OnStop();
                Started = false;
            }

            return state;
        }

        public abstract void OnStart();
        public abstract void OnStop();
        public abstract State OnUpdate();



    }
}

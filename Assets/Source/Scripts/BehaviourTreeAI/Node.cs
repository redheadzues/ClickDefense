using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public abstract class Node : ScriptableObject
    {
        [HideInInspector] public State State  = State.RUNNING;
        [HideInInspector] public bool Started = false;
        [HideInInspector] public string Guid;
        [HideInInspector] public Vector2 UIPosition; 

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

        public virtual Node Clone() =>
            Instantiate(this);
  
        public abstract void OnStart();
        public abstract void OnStop();
        public abstract State OnUpdate();



    }
}

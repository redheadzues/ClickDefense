using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public abstract class Node : ScriptableObject
    {
        [HideInInspector] public State State  = State.RUNNING;
        [HideInInspector] public bool Started = false;
        [HideInInspector] public string Guid;
        [HideInInspector] public Vector2 UIPosition;

        public State Evaluate(float time)
        {
            if (Started == false)
            {
                OnStart();
                Started = true;
            }

            State = OnEvaluate(time);

            if (State == State.FAILURE || State == State.SUCCESS)
            {
                OnStop();
                Started = false;
            }

            return State;
        }

        public virtual Node Clone() =>
            Instantiate(this);

        public System.Type GetNodeType()
        {
            System.Type result = GetType();

            return result;
        }

  
        public virtual void OnStart() { }
        public virtual void OnStop() { }
        public abstract State OnEvaluate(float time);



    }
}

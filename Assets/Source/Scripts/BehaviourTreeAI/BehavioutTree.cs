using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    [CreateAssetMenu()]
    public class BehavioutTree : ScriptableObject
    {
        public Node RootNode;
        public State TreeState = State.RUNNING;
                
        public State Update()
        {
            if(RootNode.State == State.RUNNING)
                TreeState = RootNode.Update();

            return TreeState;
        }
    }
}

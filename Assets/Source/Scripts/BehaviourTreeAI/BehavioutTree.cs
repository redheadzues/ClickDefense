using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    [CreateAssetMenu()]
    public class BehavioutTree : ScriptableObject
    {
        public Node RootNode;
        public State TreeState = State.RUNNING;
                
        public State Update() =>
            RootNode.Update();
    }
}

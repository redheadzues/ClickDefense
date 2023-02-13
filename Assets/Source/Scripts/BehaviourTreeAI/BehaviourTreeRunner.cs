using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class BehaviourTreeRunner : MonoBehaviour
    {
        [SerializeField] private BehaviourTree tree;

        private void Start()
        {
            DebugLogNode log1 = ScriptableObject.CreateInstance<DebugLogNode>();
            log1.Message = "111";

            WaitNode pause1 = ScriptableObject.CreateInstance<WaitNode>();

            DebugLogNode log2 = ScriptableObject.CreateInstance<DebugLogNode>();
            log2.Message = "222";  

            WaitNode pause2 = ScriptableObject.CreateInstance<WaitNode>();
            
            DebugLogNode log3 = ScriptableObject.CreateInstance<DebugLogNode>();
            log3.Message = "333";

            WaitNode pause3 = ScriptableObject.CreateInstance<WaitNode>();

            SequencerNode sequence = ScriptableObject.CreateInstance<SequencerNode>();
            sequence.Children.Add(log1);
            sequence.Children.Add(pause1);
            sequence.Children.Add(log2);
            sequence.Children.Add(pause1);
            sequence.Children.Add(log3);
            sequence.Children.Add(pause1);


            RepeatNode repeat = ScriptableObject.CreateInstance<RepeatNode>();
            repeat.child = sequence;

            tree.RootNode = repeat;
        }

        private void Update()
        {
            tree.Update();
        }
    }
}

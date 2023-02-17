using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class DebugLogNode : ActionNode
    {
        public string Message;
        public Transform TransformForPrint;
        [Shared] 
        [SerializeField]public TowerSetter TowerSetter;

        public override State OnEvaluate(float time)
        {
                Debug.Log($"OnUpdate ");

            return State.SUCCESS;
        }
    }
}

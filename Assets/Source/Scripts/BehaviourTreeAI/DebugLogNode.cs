using System;
using UnityEngine;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class DebugLogNode : ActionNode
    {
        public string Message;

        public override void OnStart() =>
            Debug.Log($"OnStart {Message}");


        public override void OnStop() => 
            Debug.Log($"OnStop {Message}");

        public override State OnUpdate()
        {
            Debug.Log($"OnUpdate {Message}");
            return State.SUCCESS;
        }
    }
}

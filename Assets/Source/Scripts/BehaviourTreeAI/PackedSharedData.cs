using System;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    public class PackedSharedData
    {
        public Type Type;
        public string Name;
        public object Value;

        public PackedSharedData(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}

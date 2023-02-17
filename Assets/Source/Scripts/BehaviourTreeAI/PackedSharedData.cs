using System;

namespace Assets.Source.Scripts.BehaviourTreeAI
{
    [Serializable]
    public class PackedSharedData
    {
        public string Name;
        public object Value;
        private Type _type;        

        public Type Type  { get { return _type ?? Value.GetType(); }  }

        public PackedSharedData(Type type, string name)
        {
            Name = name;
            _type = type;
        }
    }
}

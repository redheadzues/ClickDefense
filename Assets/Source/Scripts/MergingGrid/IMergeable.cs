using System;

namespace Assets.Source.Scripts.MergingGrid
{
    public interface IMergeable
    {
        Enum Type { get; }
        int Level { get; }
        bool Merge(IMergeable merged);
        void Destroy();
    }
}
using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.MergingGrid
{
    public interface IMergeable
    {
        Enum Type { get; }
        int Level { get; }
        bool Merge(IMergeable merged);
        void Destroy();
    }

    public interface IMergableParent : IMergeable
    {
        IReadOnlyList<IMergeableChild> Childs { get; }
    }

    public interface IMergeableChild : IMergeable
    {

    }
}
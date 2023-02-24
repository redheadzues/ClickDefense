using System.Collections.Generic;

namespace Assets.Source.Scripts.MergingGrid
{
    public interface IMergableParent : IMergeable
    {
        IReadOnlyList<IMergeableChild> Childs { get; }
    }
}
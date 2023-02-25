using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public interface IMergeableChild : IMergeable
    {
        void SetParrent(Transform parrent);
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public interface IMergeableGridCell
    {
        IMergeable Content { get; }
        Transform Transform { get; }
        bool Merge(IMergeableGridCell merged);
        void Destroy();
    }
}

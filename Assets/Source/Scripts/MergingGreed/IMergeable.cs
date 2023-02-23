using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public interface IMergeable : ICellContent
    {
        void Merge();
        void Destroy();
    }
}

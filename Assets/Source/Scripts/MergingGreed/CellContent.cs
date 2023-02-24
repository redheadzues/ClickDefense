using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public class CellContent : IMergeableGridCell  
    {
        private readonly IMergeable _content;
        private readonly Transform _transform;

        public Transform Transform => _transform;
        public IMergeable Content => _content;

        public CellContent(IMergeable content, Transform transform)
        {
            _content = content;
            _transform = transform;
        }

        public void Destroy()
        {
            _content.Destroy();
        }

        public bool Merge(IMergeableGridCell merged)
        {
            return _content.Merge(merged.Content);
        }
    }
}

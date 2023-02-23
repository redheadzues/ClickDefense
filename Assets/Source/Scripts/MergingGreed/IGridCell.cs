using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public interface IGridCell
    {
        TContent GetContent<TType, TContent>() where TType : class, ICellContent where TContent : ICellContent;
        void SetContent<TType>(ICellContent content) where TType : class, ICellContent ;
        void SetContentOnPosition(Vector3 position);
    }
}

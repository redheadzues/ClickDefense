using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public class CellContent : IGridCell
    {
        private Dictionary<Type, ICellContent> _content;

        TContent IGridCell.GetContent<TType, TContent>() =>
        _content.ContainsKey(typeof(TType)) ? (TContent)_content[typeof(TType)] : default(TContent);

        void IGridCell.SetContent<TType>(ICellContent content) => 
            _content.Add(typeof(TType), content);

        public void SetContentOnPosition(Vector3 position)
        {

            foreach(ICellContent value in _content.Values)
                value.SetPosition(position);
        }
    }
}

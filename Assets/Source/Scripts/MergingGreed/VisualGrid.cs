using System;
using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public class VisualGrid : IDisposable
    {
        private VisualGridCell _template;
        private Transform _transformVisualGridParent;
        private Grid _grid;
        private Vector3 _gridStartPosition;

        private VisualGridCell[,] _visualGrid;
        private GridType _gridType;
        private bool _displayed;

        public GridType GridType => _gridType;
        public event Action<VisualGridCell> CellSelected;

        public VisualGrid(VisualGridCell template, Transform transformVisualGridParent, Grid grid, Vector3 gridStartPosition)
        {
            _template = template;
            _transformVisualGridParent = transformVisualGridParent;
            _grid = grid;
            _gridStartPosition = gridStartPosition;

            CreateVisualGrid();
        }

        public void Dispose()
        {
            for (int x = 0; x < _visualGrid.GetLength(0); x++)
                for (int y = 0; y < _visualGrid.GetLength(1); y++)
                    _visualGrid[x, y].CellSelected -= OnCellSelected;
        }

        public Vector3 GetWorldPosition(Vector2Int gridPosition) =>
            _visualGrid[gridPosition.x, gridPosition.y].transform.position;

        public VisualGridCell GetCoverCell()
        {

            for (int x = 0; x < _visualGrid.GetLength(0); x++)
            {
                for (int y = 0; y < _visualGrid.GetLength(1); y++)
                {
                    if (_visualGrid[x, y].IsMouseOver == true)
                        return _visualGrid[x, y];
                }
            }

            return null;
        }


        public void SwitchDisplayMode()
        {
            for (int x = 0; x < _grid.Size.x; x++)
            {
                for (int y = 0; y < _grid.Size.y; y++)
                {
                    if (_displayed == true)
                        _visualGrid[x, y].gameObject.SetActive(true);
                    else
                        _visualGrid[x, y].gameObject.SetActive(false);
                }
            }
        }


        private void CreateVisualGrid()
        {
            _gridType = _grid.GridType;
            _visualGrid = new VisualGridCell[_grid.Size.x, _grid.Size.y];

            for (int x = 0; x < _grid.Size.x; x++)
            {
                for (int y = 0; y < _grid.Size.y; y++)
                {
                    CreateVisualCell(x, y);
                }
            }
        }

        private void CreateVisualCell(int x, int y)
        {
            Vector3 point = new Vector3(_gridStartPosition.x + x * 2, 0.6f, _gridStartPosition.z - y * 2);
            VisualGridCell cell = GameObject.Instantiate(_template, point, Quaternion.Euler(90, 0, 0), _transformVisualGridParent);
            cell.transform.localScale *= 1.8f;
            cell.PositionOnGrid = new Vector2Int(x, y);
            cell.CellSelected += OnCellSelected;
            cell.Owner = _grid.GridType;
            _visualGrid[x, y] = cell;
        }

        private void OnCellSelected(VisualGridCell cell)
        {
            CellSelected?.Invoke(cell);
        }
    }
}

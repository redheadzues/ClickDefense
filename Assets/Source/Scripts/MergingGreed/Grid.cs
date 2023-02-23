using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public class Grid
    {
        private Vector2Int _gridSize;
        private int _capacity;
        private GridType _gridType;

        private IGridCell[,] _grid;

        public Vector2Int Size => _gridSize;
        public GridType GridType => _gridType;

        public Grid(Vector2Int gridSize, GridType gridType, int capacity = 0)
        {
            _gridSize = gridSize;
            _capacity = capacity;
            _gridType = gridType;

            if (_gridType == GridType.Reserve)
                _capacity = _grid.Length;

            CreateGrid();
        }

        public Vector2Int GetEmptyCell()
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                for (int y = 0; y < _gridSize.y; y++)
                {
                    if (_grid[x, y] == null)
                        return new Vector2Int(x, y);
                }
            }

            return -Vector2Int.one;
        }

        public bool SetContent(IGridCell content, Vector2Int position)
        {
            if (GetContent(position) == null && CheckCapacity())
            {
                _grid[position.x, position.y] = content;
                return true;
            }

            return false;
        }

        private bool CheckCapacity()
        {
            int count = 0;

            for (int x = 0; x < _gridSize.x; x++)
                for (int y = 0; y < _gridSize.y; y++)
                    if (_grid[x, y] != null)
                        count++;

            return count < _capacity;
        }

        public IGridCell GetContent(Vector2Int position) =>
            _grid[position.x, position.y];

        public void DeleteContent(Vector2Int position) =>
            _grid[position.x, position.y] = null;

        private void CreateGrid()
        {
            _grid = new IGridCell[_gridSize.x, _gridSize.y];

            for (int i = 0; i < _gridSize.x; i++)
                for (int j = 0; j < _gridSize.y; j++)
                    _grid[i, j] = null;
        }
    }
}

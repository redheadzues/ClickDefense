using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] private Vector2Int _gridSize;
        [SerializeField] private int _capacity;
        [SerializeField] private GridType _gridType;

        private IMergeableGridCell[,] _grid;

        public Vector2Int Size => _gridSize;
        public GridType GridType => _gridType;

        public void Start()
        {
            CreateGrid();

            if (_gridType == GridType.Reserve)
                _capacity = _grid.Length;
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

        public bool SetContent(IMergeableGridCell content, Vector2Int position)
        {
            if (GetContent(position) == null && CheckCapacity())
            {
                _grid[position.x, position.y] = content;
                return true;
            }

            return false;
        }



        public IMergeableGridCell GetContent(Vector2Int position) =>
            _grid[position.x, position.y];

        public void DeleteContent(Vector2Int position) =>
            _grid[position.x, position.y] = null;

        private bool CheckCapacity()
        {
            int count = 0;

            for (int x = 0; x < _gridSize.x; x++)
                for (int y = 0; y < _gridSize.y; y++)
                    if (_grid[x, y] != null)
                        count++;

            return count < _capacity;
        }

        private void CreateGrid()
        {
            _grid = new CellContent[_gridSize.x, _gridSize.y];

            for (int i = 0; i < _gridSize.x; i++)
                for (int j = 0; j < _gridSize.y; j++)
                    _grid[i, j] = null;
        }
    }
}




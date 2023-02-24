using Assets.Source.Scripts.MergingGrid;
using UnityEngine;

public class MonoBehaviourGrid : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private int _capacity;
    [SerializeField] private GridType _gridType;

    private TestCubeMerge[,] _grid;

    public TestCubeMerge[,] Greed => _grid;
    public GridType GridType => _gridType;  

    private void Awake()
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

    public bool SetCube(TestCubeMerge cube, Vector2Int position)
    {
        if(GetCube(position) == null && CheckCapacity())
        {
            _grid[position.x, position.y] = cube;
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

    public TestCubeMerge GetCube(Vector2Int position) => 
        _grid[position.x, position.y];

    public void DeleteCube(Vector2Int position) => 
        _grid[position.x, position.y] = null;

    private void CreateGrid()
    {
        _grid = new TestCubeMerge[_gridSize.x, _gridSize.y];

        for (int i = 0; i < _gridSize.x; i++)
            for (int j = 0; j < _gridSize.y; j++)
                _grid[i, j] = null;
    }
}




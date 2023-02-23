using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize;

    private TestCubeMerge[,] _grid;
    public TestCubeMerge[,] Greed => _grid;

    private void Awake()
    {
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

    public void SetCube(TestCubeMerge cube, Vector2Int position) => 
        _grid[position.x, position.y] = cube;

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

public class GridDataCell
{
    public object Owner;
    public TestCubeMerge Cube;

    public GridDataCell(object owner, TestCubeMerge cube)
    {
        Owner = owner;
        Cube = cube;
    }
}

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

    private void CreateGrid()
    {
        _grid = new TestCubeMerge[_gridSize.x, _gridSize.y];

        for (int i = 0; i < _gridSize.x; i++)
            for (int j = 0; j < _gridSize.y; j++)
                _grid[i, j] = null;
    }

    //public bool TryBuild(int positionX, int positionY, int borderSize)
    //{
    //    if (CheckAvailabilityBuild(positionX, positionY) == true)
    //    {
    //        Vector2 gridPosition = DefineGridPosition(positionX, positionY);

    //        for (int i = (int)gridPosition.x - borderSize; i < gridPosition.x + borderSize + 1; i++)
    //            if(i >= 0 && i < _columnsCount)
    //                for (int j = (int)gridPosition.y - borderSize; j < gridPosition.y + borderSize + 1; j++)
    //                    if(j >= 0 && j < _rowsCount)
    //                        _grid[i, j] = false;

    //        return true;
    //    }
    //    else
    //    {
    //        print("Нельзя");
    //        return false;
    //    }
    //}



    //private bool CheckAvailabilityBuild(int positionX, int positionY)
    //{
    //    Vector2 gridPosition = DefineGridPosition(positionX, positionY);

    //    if ((gridPosition.x >= _columnsCount) || (gridPosition.x < 0))
    //        return false;
    //    if ((gridPosition.y >= _rowsCount) || (gridPosition.y < 0))
    //        return false;

    //    return _grid[(int)gridPosition.x, (int)gridPosition.y];
    //}

    //private Vector2  DefineGridPosition(int positionX, int positionY)
    //{
    //    int XpostitionOnGrid = positionX - ((int)_gridStartPosition.x);
    //    int YpostitionOnGrid = ((int)_gridStartPosition.z) - positionY;

    //    return new Vector2(XpostitionOnGrid, YpostitionOnGrid);
    //}
}

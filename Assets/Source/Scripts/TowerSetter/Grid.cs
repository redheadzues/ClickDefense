using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] protected int _columnsCount;
    [SerializeField] protected int _rowsCount;

    private bool[,] _grid;
    public bool[,] Greed => _grid;

    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        _grid = new bool[_columnsCount, _rowsCount];

        for (int i = 0; i < _columnsCount; i++)
            for (int j = 0; j < _rowsCount; j++)
                _grid[i, j] = true;
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

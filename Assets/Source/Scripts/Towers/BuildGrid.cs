using UnityEngine;

public class BuildGrid : MonoBehaviour
{
    [SerializeField] private int _rowsCount;
    [SerializeField] private int _columnsCount;
    [SerializeField] private Vector3 _gridStartPosition;

    private bool[,] grid;

    private void Awake()
    {
        grid = new bool[_rowsCount, _columnsCount];
    }

    private void Start()
    {
        for (int i = 0; i < _rowsCount; i++)
            for (int j = 0; j < _columnsCount; j++)
            {
                grid[i, j] = true;
            }
    }

    public bool TryBuild(int positionX, int positionY, int borderSize)
    {
        if (CheckAvailabilityBuild(positionX, positionY) == true)
        {
            Vector2 gridPosition = DefineGridPosition(positionX, positionY);

            for (int i = (int)gridPosition.x - borderSize; i < gridPosition.x + borderSize + 1; i++)
                if(i >= 0 && i < _rowsCount)
                    for (int j = (int)gridPosition.y - borderSize; j < gridPosition.y + borderSize + 1; j++)
                        if(j >= 0 && j < _columnsCount)
                            grid[i, j] = false;

            return true;
        }
        else
        {
            print("Нельзя");
            return false;
        }

    }

    private bool CheckAvailabilityBuild(int positionX, int positionY)
    {
        Vector2 gridPosition = DefineGridPosition(positionX, positionY);
        print(positionX + " " + positionY);
        print(gridPosition.x + " " + gridPosition.y);

        if ((gridPosition.x >= _rowsCount) || (gridPosition.x < 0))
        {
            print(false);
            return false;
        }
        if ((gridPosition.y >= _columnsCount) || (gridPosition.y < 0))
        {
            print(false);
            return false;
        }


        return grid[(int)gridPosition.x, (int)gridPosition.y];
    }

    private Vector2  DefineGridPosition(int positionX, int positionY)
    {
        int XpostitionOnGrid = positionX - ((int)_gridStartPosition.x);
        int YpostitionOnGrid = ((int)_gridStartPosition.z) - positionY;

        return new Vector2(XpostitionOnGrid, YpostitionOnGrid);
    }
}

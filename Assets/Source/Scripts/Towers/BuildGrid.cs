using System;
using UnityEngine;

public class BuildGrid : MonoBehaviour
{
    [SerializeField] protected int _columnsCount;
    [SerializeField] protected int _rowsCount;
    [SerializeField] private Vector3 _gridStartPosition;
    [SerializeField] private SpriteRenderer _spriteCell;
    [SerializeField] private Color _colorEnable;
    [SerializeField] private Color _colorDisable;
    [SerializeField] private ModeSwitcher _modeSwitcher;
    [SerializeField] private Transform _transformVisualGridParent;


    private SpriteRenderer[,] _visualGrid;
    private bool[,] grid;

    private void Awake()
    {
        CreateGrid();
        CreateVisualGrid();
    }

    private void OnEnable()
    {
        _modeSwitcher.BuildingModeChanged += OnBuildingModeChange;
    }

    private void OnDisable()
    {
        _modeSwitcher.BuildingModeChanged -= OnBuildingModeChange;
    }


    public bool TryBuild(int positionX, int positionY, int borderSize)
    {
        if (CheckAvailabilityBuild(positionX, positionY) == true)
        {
            Vector2 gridPosition = DefineGridPosition(positionX, positionY);

            for (int i = (int)gridPosition.x - borderSize; i < gridPosition.x + borderSize + 1; i++)
                if(i >= 0 && i < _columnsCount)
                    for (int j = (int)gridPosition.y - borderSize; j < gridPosition.y + borderSize + 1; j++)
                        if(j >= 0 && j < _rowsCount)
                            grid[i, j] = false;

            ColorizeGrid();

            return true;
        }
        else
        {
            print("Нельзя");
            return false;
        }
    }

    private void CreateGrid()
    {
        grid = new bool[_columnsCount, _rowsCount];

        for (int i = 0; i < _columnsCount; i++)
            for (int j = 0; j < _rowsCount; j++)
                grid[i, j] = true;
    }

    private bool CheckAvailabilityBuild(int positionX, int positionY)
    {
        Vector2 gridPosition = DefineGridPosition(positionX, positionY);

        if ((gridPosition.x >= _columnsCount) || (gridPosition.x < 0))
            return false;
        if ((gridPosition.y >= _rowsCount) || (gridPosition.y < 0))
            return false;


        return grid[(int)gridPosition.x, (int)gridPosition.y];
    }

    private Vector2  DefineGridPosition(int positionX, int positionY)
    {
        int XpostitionOnGrid = positionX - ((int)_gridStartPosition.x);
        int YpostitionOnGrid = ((int)_gridStartPosition.z) - positionY;

        return new Vector2(XpostitionOnGrid, YpostitionOnGrid);
    }

    private void CreateVisualGrid()
    {
        _visualGrid = new SpriteRenderer[_columnsCount, _rowsCount];

        for (int i = 0; i < _columnsCount; i++)
            for (int j = 0; j < _rowsCount; j++)
            {
                Vector3 point = new Vector3(_gridStartPosition.x + i, 0.6f, _gridStartPosition.z - j);
                SpriteRenderer sprite = Instantiate(_spriteCell, point, Quaternion.Euler(90, 0, 0), _transformVisualGridParent);
                _visualGrid[i, j] = sprite;
            }

        ColorizeGrid();
    }

    private void ColorizeGrid()
    {
        for (int i = 0; i < _columnsCount; i++)
            for (int j = 0; j < _rowsCount; j++)
            {
                if (grid[i, j] == true)
                    _visualGrid[i, j].color = _colorEnable;
                else
                    _visualGrid[i, j].color = _colorDisable;
            }
    }

    private void OnBuildingModeChange()
    {
        for(int i = 0; i < _columnsCount; i++)
            for(int j = 0; j < _rowsCount; j++)
            {
                if (_modeSwitcher.IsBuildModeActivated == true)
                    _visualGrid[i, j].gameObject.SetActive(true);
                else
                    _visualGrid[i, j].gameObject.SetActive(false);
            }
    }
}

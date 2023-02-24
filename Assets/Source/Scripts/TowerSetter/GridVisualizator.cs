using Assets.Source.Scripts.MergingGrid;
using System;
using UnityEngine;

public class GridVisualizator : MonoBehaviour
{
    [SerializeField] private ModeSwitcher _modeSwitcher;
    [SerializeField] private VisualGridCell _spriteCell;
    [SerializeField] private Color _colorEnable;
    [SerializeField] private Color _colorDisable;
    [SerializeField] private Transform _transformVisualGridParent;
    [SerializeField] private Grid _grid;
    [SerializeField] private Vector3 _gridStartPosition;

    private VisualGridCell[,] _visualGrid;
    private GridType _gridType;

    public GridType GridType => _gridType;
    public event Action<VisualGridCell> CellSelected;

    private void OnEnable() => 
        _modeSwitcher.BuildingModeChanged += OnBuildingModeChange;

    private void Start() =>
        CreateVisualGrid();

    private void OnDisable()
    {
        _modeSwitcher.BuildingModeChanged -= OnBuildingModeChange;

        for(int x = 0; x < _visualGrid.GetLength(0); x++)
            for(int y = 0; y < _visualGrid.GetLength(1); y++)
                _visualGrid[x, y].CellSelected -= OnCellSelected;   
    }

    public Vector3 GetWorldPosition(Vector2Int gridPosition) =>
        _visualGrid[gridPosition.x, gridPosition.y].transform.position;

    public VisualGridCell GetCoverCell()
    {

        for(int x = 0; x < _visualGrid.GetLength(0); x++)
        {
            for (int y = 0; y < _visualGrid.GetLength(1); y++)
            {
                if (_visualGrid[x, y].IsMouseOver == true)
                    return _visualGrid[x,y];
            }
        }

        return null;

    }
    

    private void OnBuildingModeChange()
    {
        for (int x = 0; x < _grid.Greed.GetLength(0); x++)
            for (int y = 0; y < _grid.Greed.GetLength(1); y++)
            {
                if (_modeSwitcher.IsBuildModeActivated == true)
                    _visualGrid[x, y].gameObject.SetActive(true);
                else
                    _visualGrid[x, y].gameObject.SetActive(false);
            }
    }

    private void ColorizeGrid()
    {
        for (int x = 0; x < _grid.Greed.GetLength(0); x++)
            for (int y = 0; y < _grid.Greed.GetLength(1); y++)
            {
                if (_grid.Greed[x, y] == null)
                    _visualGrid[x, y].SetColor(_colorEnable);
                else
                    _visualGrid[x, y].SetColor(_colorDisable);
            }
    }

    private void CreateVisualGrid()
    {
        _gridType = _grid.GridType;
        _visualGrid = new VisualGridCell[_grid.Greed.GetLength(0), _grid.Greed.GetLength(1)];

        for (int x = 0; x < _grid.Greed.GetLength(0); x++)
            for (int y = 0; y < _grid.Greed.GetLength(1); y++)
            {
                Vector3 point = new Vector3(_gridStartPosition.x + x * 2, 0.6f, _gridStartPosition.z - y * 2);
                VisualGridCell cell = Instantiate(_spriteCell, point, Quaternion.Euler(90, 0, 0), _transformVisualGridParent);
                cell.transform.localScale *= 1.8f;
                cell.PositionOnGrid = new Vector2Int(x, y);
                cell.CellSelected += OnCellSelected;
                cell.Owner = _grid.GridType;
                _visualGrid[x, y] = cell;
            }

        ColorizeGrid();
    }

    private void OnCellSelected(VisualGridCell cell)
    {
        CellSelected?.Invoke(cell);
    }
}

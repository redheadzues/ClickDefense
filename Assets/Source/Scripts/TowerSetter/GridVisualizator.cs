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

    private void OnEnable()
    {
        _modeSwitcher.BuildingModeChanged += OnBuildingModeChange;
    }

    private void Start()
    {
        CreateVisualGrid();
    }

    private void OnDisable()
    {
        _modeSwitcher.BuildingModeChanged -= OnBuildingModeChange;
    }

    private void OnBuildingModeChange()
    {
        for (int i = 0; i < _grid.Greed.GetLength(0); i++)
            for (int j = 0; j < _grid.Greed.GetLength(1); j++)
            {
                if (_modeSwitcher.IsBuildModeActivated == true)
                    _visualGrid[i, j].gameObject.SetActive(true);
                else
                    _visualGrid[i, j].gameObject.SetActive(false);
            }
    }

    private void ColorizeGrid()
    {
        for (int i = 0; i < _grid.Greed.GetLength(0); i++)
            for (int j = 0; j < _grid.Greed.GetLength(1); j++)
            {
                if (_grid.Greed[i, j] == true)
                    _visualGrid[i, j].SetColor(_colorEnable);
                else
                    _visualGrid[i, j].SetColor(_colorDisable);
            }
    }

    private void CreateVisualGrid()
    {
        _visualGrid = new VisualGridCell[_grid.Greed.GetLength(0), _grid.Greed.GetLength(1)];

        for (int i = 0; i < _grid.Greed.GetLength(0); i++)
            for (int j = 0; j < _grid.Greed.GetLength(1); j++)
            {
                Vector3 point = new Vector3(_gridStartPosition.x + i * 2, 0.6f, _gridStartPosition.z - j * 2);
                VisualGridCell sprite = Instantiate(_spriteCell, point, Quaternion.Euler(90, 0, 0), _transformVisualGridParent);
                sprite.transform.localScale *= 1.8f;
                _visualGrid[i, j] = sprite;
            }

        ColorizeGrid();
    }
}

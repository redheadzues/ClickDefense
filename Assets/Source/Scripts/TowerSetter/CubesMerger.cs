using UnityEngine;

public class CubesMerger : MonoBehaviour
{
    [SerializeField] private TestCubeMerge _cube;
    [SerializeField] private Grid _grid;
    [SerializeField] private GridVisualizator _visualGrid;
    [SerializeField] private CubeMover _cubeMover;

    private TestCubeMerge _selectedCube;
    private bool _isSelected;

    private void OnEnable()
    {
        _visualGrid.CellSelected += OnCellSelected;
    }

    private void OnDisable()
    {
        _visualGrid.CellSelected -= OnCellSelected;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            InstantiateCube();
    }

    private void OnCellSelected(Vector2Int position)
    {
        _selectedCube = _grid.GetCube(position);


        if (_selectedCube != null)
        {
            _isSelected = true;
            _cubeMover.StartMove(_selectedCube.transform);
        }
    }

    private void InstantiateCube()
    {
        TestCubeMerge cube = Instantiate(_cube);
        SetOnPosition(cube);
    }

    private void SetOnPosition(TestCubeMerge cube)
    {
        Vector2Int gridPosition = _grid.GetEmptyCell();

        if (gridPosition == -Vector2Int.one)
            return;

        cube.transform.position = _visualGrid.GetWorldPosition(gridPosition);
        _grid.SetCube(cube, gridPosition);
    }
}

using UnityEngine;

public class CubesMerger : MonoBehaviour
{
    [SerializeField] private TestCubeMerge _cube;
    [SerializeField] private Grid _grid;
    [SerializeField] private GridVisualizator _visualGrid;
    [SerializeField] private CubeMover _cubeMover;

    private TestCubeMerge _selectedCube;
    private VisualGridCell _lastCell;

    private void OnEnable()
    {
        _visualGrid.CellSelected += OnCellSelected;
        _cubeMover.MouseReleased += OnMouseReleased;
    }

    private void OnDisable()
    {
        _visualGrid.CellSelected -= OnCellSelected;
        _cubeMover.MouseReleased -= OnMouseReleased;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            InstantiateCube();
    }

    private void OnCellSelected(VisualGridCell cell)
    {
        _selectedCube = _grid.GetCube(cell.PositionOnGrid);
        

        if (_selectedCube != null)
        {
            _cubeMover.StartMove(_selectedCube.transform);
            _lastCell = cell;
        }
    }

    private void InstantiateCube()
    {
        TestCubeMerge cube = Instantiate(_cube);
        SetOnEmptyPosition(cube);
    }

    private void SetOnEmptyPosition(TestCubeMerge cube)
    {
        Vector2Int gridPosition = _grid.GetEmptyCell();

        if (gridPosition == -Vector2Int.one)
            return;

        cube.transform.position = _visualGrid.GetWorldPosition(gridPosition);
        _grid.SetCube(cube, gridPosition);
    }

    private void OnMouseReleased(Vector3 point)
    {
        VisualGridCell visualCell = _visualGrid.GetCoverCell();

        if (visualCell == null || visualCell == _lastCell)
        {
            SetCubeOnLastPosition();
        }
        else
        {
            TestCubeMerge cube = _grid.GetCube(visualCell.PositionOnGrid);

            if (cube == null)
                SetCubeOnNewPosition(visualCell);
            else
            {
                if (cube.level == _selectedCube.level)
                {
                    MergeCubes(cube);
                }
                else
                    SetCubeOnLastPosition();
            }
        }

        _selectedCube = null;
    }

    private void MergeCubes(TestCubeMerge cube)
    {
        cube.level++;
        Destroy(_selectedCube.gameObject);
        _grid.DeleteCube(_lastCell.PositionOnGrid);
    }

    private void SetCubeOnLastPosition()
    {
        _selectedCube.transform.position = _lastCell.transform.position;
    }

    private void SetCubeOnNewPosition(VisualGridCell visualCell)
    {
        _selectedCube.transform.position = visualCell.transform.position;
        _grid.DeleteCube(_lastCell.PositionOnGrid);
        _grid.SetCube(_selectedCube, visualCell.PositionOnGrid);
    }
}

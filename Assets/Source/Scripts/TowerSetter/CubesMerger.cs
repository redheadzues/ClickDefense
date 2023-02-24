using System.Collections.Generic;
using UnityEngine;

public class CubesMerger : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviourGrid> _grids;
    [SerializeField] private List<GridVisualizator> _visualGrids;
    [SerializeField] private CubeMover _cubeMover;

    private TestCubeMerge _selectedCube;
    private VisualGridCell _lastCell;

    private void OnEnable()
    {
        _visualGrids.ForEach(x => x.CellSelected += OnCellSelected);
        _cubeMover.MouseReleased += OnMouseReleased;
    }

    private void OnDisable()
    {
        _visualGrids.ForEach(x => x.CellSelected -= OnCellSelected);
        _cubeMover.MouseReleased -= OnMouseReleased;
    }


    private void OnCellSelected(VisualGridCell cell)
    {
        MonoBehaviourGrid cellOwner = GetOwner(cell);

        _selectedCube = cellOwner.GetCube(cell.PositionOnGrid);        

        if (_selectedCube != null)
        {
            _cubeMover.StartMove(_selectedCube.transform);
            _lastCell = cell;
        }
    }

    private MonoBehaviourGrid GetOwner(VisualGridCell cell)
    {
        foreach(MonoBehaviourGrid grid in _grids)
            if(grid.GridType == cell.Owner)
                return grid;

        return null;
    }


    private void OnMouseReleased()
    {
        VisualGridCell visualCell = GetCoverCell();

        if (visualCell == null || visualCell == _lastCell)
        {
            SetCubeOnLastPosition();
        }
        else
        {
            MonoBehaviourGrid grid = GetOwner(visualCell);

            TestCubeMerge cube = grid.GetCube(visualCell.PositionOnGrid);

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

    private VisualGridCell GetCoverCell()
    {
        foreach (GridVisualizator visualGrid in _visualGrids)
        {
            var coverCell = visualGrid.GetCoverCell();

            if (coverCell != null)
                return coverCell;
        }

        return null;            
    }

    private void MergeCubes(TestCubeMerge cube)

    {
        cube.level++;
        Destroy(_selectedCube.gameObject);

        MonoBehaviourGrid gridToMerge = GetOwner(_lastCell);

        gridToMerge.DeleteCube(_lastCell.PositionOnGrid);
    }

    private void SetCubeOnLastPosition()
    {
        _selectedCube.transform.position = _lastCell.transform.position;
    }

    private void SetCubeOnNewPosition(VisualGridCell visualCell)
    {
        MonoBehaviourGrid gridToSetCube = GetOwner(visualCell);

        if(gridToSetCube.SetCube(_selectedCube, visualCell.PositionOnGrid))
        {

            _selectedCube.transform.position = visualCell.transform.position;
            MonoBehaviourGrid gridForDeleteCell = GetOwner(_lastCell);
            gridForDeleteCell.DeleteCube(_lastCell.PositionOnGrid);
        }
        else
            SetCubeOnLastPosition();
    }
}

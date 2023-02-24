using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public class CubesMerger : MonoBehaviour
    {
        [SerializeField] private List<Grid> _grids;
        [SerializeField] private List<GridVisualizator> _visualGrids;
        [SerializeField] private GridCellMover _cubeMover;

        private IMergeableGridCell _selectedCell;
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
            Grid cellOwner = GetOwner(cell);

            _selectedCell = cellOwner.GetContent(cell.PositionOnGrid);

            if (_selectedCell != null)
            {
                _cubeMover.StartMove(_selectedCell.Transform);
                _lastCell = cell;
            }
        }

        private Grid GetOwner(VisualGridCell cell)
        {
            foreach (Grid grid in _grids)
                if (grid.GridType == cell.Owner)
                    return grid;

            return null;
        }


        private void OnMouseReleased()
        {
            VisualGridCell visualCell = GetCoverCell();

            if (visualCell == null || visualCell == _lastCell)
            {
                SetCellOnLastPosition();
            }
            else
            {
                Grid grid = GetOwner(visualCell);

                IMergeableGridCell cell = grid.GetContent(visualCell.PositionOnGrid);

                if (cell == null)
                    SetCubeOnNewPosition(visualCell);
                else
                {
                    if (cell.Merge(_selectedCell) == false)
                        SetCellOnLastPosition();
                }
            }

            _selectedCell = null;
        }

        private VisualGridCell GetCoverCell()
        {
            foreach (GridVisualizator visualGrid in _visualGrids)
            {
                VisualGridCell coverCell = visualGrid.GetCoverCell();

                if (coverCell != null)
                    return coverCell;
            }

            return null;
        }

        private void MergeCubes(IMergeableGridCell cube)
        {
            _selectedCell.Destroy();
            Grid gridToMerge = GetOwner(_lastCell);
            gridToMerge.DeleteContent(_lastCell.PositionOnGrid);
        }

        private void SetCellOnLastPosition()
        {
            _selectedCell.Transform.position = _lastCell.transform.position;
        }

        private void SetCubeOnNewPosition(VisualGridCell visualCell)
        {
            Grid gridToSetCube = GetOwner(visualCell);

            if (gridToSetCube.SetContent(_selectedCell, visualCell.PositionOnGrid))
            {

                _selectedCell.Transform.position = visualCell.transform.position;

                Grid gridForDeleteCell = GetOwner(_lastCell);
                gridForDeleteCell.DeleteContent(_lastCell.PositionOnGrid);
            }
            else
                SetCellOnLastPosition();
        }
    }
}

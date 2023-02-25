using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public class CellMerger : MonoBehaviour
    {
        [SerializeField] private List<Grid> _grids;
        [SerializeField] private List<GridVisualizator> _visualGrids;
        [SerializeField] private GridCellMover _cellMover;

        private IMergeableGridCell _selectedCell;
        private VisualGridCell _lastVisualCell;

        private void OnEnable()
        {
            _visualGrids.ForEach(x => x.CellSelected += OnCellSelected);
            _cellMover.MouseReleased += OnMouseReleased;
        }

        private void OnDisable()
        {
            _visualGrids.ForEach(x => x.CellSelected -= OnCellSelected);
            _cellMover.MouseReleased -= OnMouseReleased;
        }


        private void OnCellSelected(VisualGridCell cell)
        {
            Grid cellOwner = GetOwner(cell);

            _selectedCell = cellOwner.GetContent(cell.PositionOnGrid);

            if (_selectedCell != null)
            {
                _cellMover.StartMove(_selectedCell.Transform);
                _lastVisualCell = cell;
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
            VisualGridCell currentVisualCell = GetCoverCell();

            if (CheckValidCell(currentVisualCell))
            {
                SetCellOnLastPosition();
            }
            else
            {
                IMergeableGridCell cell = GetContentFromGrid(currentVisualCell);

                if (cell == null)
                {
                    SetCellOnNewPosition(currentVisualCell, _selectedCell);
                    DeleteCellFromGrid(_lastVisualCell);
                }
                else
                {
                    IMergeableGridCell recivingCell = cell;
                    IMergeableGridCell incomingCell = _selectedCell;

                    if (IsNeedInvertMerge(cell))
                    {
                        recivingCell = _selectedCell;
                        incomingCell = cell;
                    }

                    if (TryMerge(recivingCell, incomingCell))
                    {
                        DeleteCellFromGrid(_lastVisualCell);
                        DeleteCellFromGrid(currentVisualCell);
                        SetCellOnNewPosition(currentVisualCell, recivingCell);

                        incomingCell.Destroy();
                    }
                    else
                    {
                        SetCellOnLastPosition();
                    }
                }
            }

            _selectedCell = null;
        }

        private bool CheckValidCell(VisualGridCell currentVisualCell)
        {
            return currentVisualCell == null || currentVisualCell == _lastVisualCell;
        }

        private IMergeableGridCell GetContentFromGrid(VisualGridCell currentVisualCell)
        {
            Grid grid = GetOwner(currentVisualCell);
               
            return grid.GetContent(currentVisualCell.PositionOnGrid);
        }

        private bool IsNeedInvertMerge(IMergeableGridCell cell)
        {
            return cell.Content is IMergeableChild && _selectedCell.Content is IMergableParent;
        }

        private bool TryMerge(IMergeableGridCell recivingCell, IMergeableGridCell incomingCell)
        {
            return recivingCell.Merge(incomingCell);
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

        private void SetCellOnLastPosition()
        {
            _selectedCell.Transform.position = _lastVisualCell.transform.position;
        }

        private void SetCellOnNewPosition(VisualGridCell visualCell, IMergeableGridCell gridCell)
        {
            Grid gridToSetCube = GetOwner(visualCell);

            if (gridToSetCube.SetContent(gridCell, visualCell.PositionOnGrid))
                gridCell.Transform.position = visualCell.transform.position;
            else
                SetCellOnLastPosition();
        }

        private void DeleteCellFromGrid(VisualGridCell visualCell)
        {
            Grid gridForDeleteCell = GetOwner(visualCell);
            gridForDeleteCell.DeleteContent(visualCell.PositionOnGrid);
        }
    }
}

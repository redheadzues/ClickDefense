using UnityEngine;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Allies;
using Assets.Source.Scripts.Infrustructure.StaticData;

namespace Assets.Source.Scripts.MergingGrid
{
    public class CellFactory
    {
        private readonly Grid _reserveGrid;
        private readonly GridVisualizator _visualGrid;
        private readonly ICharacterFactory _characterFactory;

        public CellFactory(Grid reserveGrid, GridVisualizator visualGrid, ICharacterFactory characterFactory)
        {
            _reserveGrid = reserveGrid;
            _visualGrid = visualGrid;
            _characterFactory = characterFactory;
        }

        public void CreateMergeEntity()
        {
            Vector2Int gridPosition = _reserveGrid.GetEmptyCell();

            if (gridPosition != -Vector2Int.one)
            {
                IGridCell gridCell = CreateGridCell();
                Vector3 positionToSet = _visualGrid.GetWorldPosition(gridPosition);
                gridCell.SetContentOnPosition(positionToSet);
                _reserveGrid.SetContent(gridCell, gridPosition);

            }
        }

        private IGridCell CreateGridCell()
        {
            GameObject character = _characterFactory.CreateAllie(AllieTypeId.Quinth);
            Allie allie = character.GetComponent<Allie>();
            IGridCell gridCell = new CellContent();
            gridCell.SetContent<Allie>(allie);
            return gridCell;
        }
    }
}

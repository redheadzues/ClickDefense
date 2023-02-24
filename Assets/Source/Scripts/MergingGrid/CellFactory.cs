using Assets.Source.Scripts.Allies;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.StaticData;
using UnityEngine;

namespace Assets.Source.Scripts.MergingGrid
{
    public class CellFactory : MonoBehaviour
    {
        [SerializeField] private Grid _reserveGrid;
        [SerializeField] private GridVisualizator _visualGrid;

        private ICharacterFactory _characterFactory;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                InstantiateCube();
        }

        public void Construct(ICharacterFactory characterFactory)
        {
            _characterFactory = characterFactory;
        }

        private void InstantiateCube()
        {
            Transform cellTransform = new GameObject("MergeableCell").transform;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Allie allie = cube.AddComponent<Allie>();
            IMergeableGridCell cell = new CellContent(allie, cellTransform);
            allie.transform.SetParent(cell.Transform);
            allie.transform.localPosition = Vector3.zero;



            SetOnEmptyPosition(cell);
        }

        private void SetOnEmptyPosition(IMergeableGridCell cell)
        {
            Vector2Int gridPosition = _reserveGrid.GetEmptyCell();

            if (gridPosition == -Vector2Int.one)
            {
                cell.Destroy();
                return;
            }

            cell.Transform.position = _visualGrid.GetWorldPosition(gridPosition);
            _reserveGrid.SetContent(cell, gridPosition);
        }
    }
}

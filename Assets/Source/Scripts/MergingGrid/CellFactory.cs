using Assets.Source.Scripts.Allies;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.StaticData;
using System;
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

            if (Input.GetKeyDown(KeyCode.W))
                InstantiateSphere();
        }

        private void InstantiateSphere()
        {
            Transform cellTransform = new GameObject("MergeableCell").transform;
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            PowerOrbMerger orb = sphere.AddComponent<PowerOrbMerger>();
            IMergeableGridCell cell = new CellContent(orb, cellTransform);
            orb.transform.SetParent(cell.Transform);
            orb.transform.localPosition = Vector3.zero;

            Destroy(orb.GetComponent<Collider>());

            SetOnEmptyPosition(cell);
        }

        public void Construct(ICharacterFactory characterFactory)
        {
            _characterFactory = characterFactory;
        }

        private void InstantiateCube()
        {
            Transform cellTransform = new GameObject("MergeableCell").transform;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            AllieMerger allie = cube.AddComponent<AllieMerger>();
            IMergeableGridCell cell = new CellContent(allie, cellTransform);
            allie.transform.SetParent(cell.Transform);
            allie.transform.localPosition = Vector3.zero;
            Destroy(cube.GetComponent<Collider>());



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

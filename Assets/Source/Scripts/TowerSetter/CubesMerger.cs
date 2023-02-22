using UnityEngine;

public class CubesMerger : MonoBehaviour
{
    [SerializeField] private TestCubeMerge _cube;
    [SerializeField] private Grid _grid;
    [SerializeField] private GridVisualizator _visualGrid;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            InstantiateCube();
    }

    private void InstantiateCube()
    {
        TestCubeMerge cube = Instantiate(_cube);
        SetOnPosition(cube);
    }

    private void SetOnPosition(TestCubeMerge cube)
    {
        Vector2Int gridPosition = _grid.GetEmptyCell();
        cube.transform.position = _visualGrid.GetWorldPosition(gridPosition);
    }
}

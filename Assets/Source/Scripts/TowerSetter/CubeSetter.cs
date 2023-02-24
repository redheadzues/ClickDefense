using UnityEngine;

public class CubeSetter : MonoBehaviour
{
    [SerializeField] private MonoBehaviourGrid _reserveGrid;
    [SerializeField] private GridVisualizator _visualGrid;
    [SerializeField] private TestCubeMerge _cubePrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            InstantiateCube();
    }

    private void InstantiateCube()
    {
        TestCubeMerge cube = Instantiate(_cubePrefab);
        SetOnEmptyPosition(cube);
    }

    private void SetOnEmptyPosition(TestCubeMerge cube)
    {
        Vector2Int gridPosition = _reserveGrid.GetEmptyCell();

        if (gridPosition == -Vector2Int.one)
        {
            Destroy(cube.gameObject);
            return;
        }

        cube.transform.position = _visualGrid.GetWorldPosition(gridPosition);
        _reserveGrid.SetCube(cube, gridPosition);
    }
}

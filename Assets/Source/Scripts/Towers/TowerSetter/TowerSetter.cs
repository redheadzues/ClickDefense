using UnityEngine;
using UnityEngine.AI;

public class TowerSetter : MonoBehaviour
{
    [SerializeField] private Tower _template;
    [SerializeField] private BuildGrid _buildGrid;
    [SerializeField] private ModeSwitcher _modeSwitcher;
    [SerializeField] private NavMeshSurface _navMeshSurface;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        if (_modeSwitcher.IsBuildModeActivated == true)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                int x = Mathf.RoundToInt(hitInfo.point.x);
                int y = Mathf.RoundToInt(hitInfo.point.z);

                if (_buildGrid.TryBuild(x, y, 2) == true)
                {
                    Instantiate(_template, new Vector3(x, _template.transform.localScale.y / 2, y), Quaternion.identity);
                    _navMeshSurface.BuildNavMesh();
                }
                    
            }
        }
    }
}

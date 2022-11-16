using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSetter : MonoBehaviour
{
    [SerializeField] private Tower _template;
    [SerializeField] private BuildGrid _buildGrid;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            int x = Mathf.RoundToInt(hitInfo.point.x);
            int y = Mathf.RoundToInt(hitInfo.point.z);

            if(_buildGrid.TryBuild(x,y, 1) == true)
                Instantiate(_template, new Vector3(x, 0.5f + _template.transform.localScale.y /2 , y), Quaternion.identity);
        }
    }

}

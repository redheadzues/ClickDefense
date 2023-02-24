using System;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private Camera _cameraMain;
    private float _distance;
    private Transform _movingTransform;

    public event Action MouseReleased; 

    private void Awake()
    {
        _cameraMain = Camera.main;
    }

    public void StartMove(Transform movingTransform)
    {
        _distance = Vector3.Distance(movingTransform.position, _cameraMain.transform.position);
        _movingTransform = movingTransform;
    }

    private void Update()
    {
        if (_movingTransform != null)
        {
            _distance = Vector3.Distance(_movingTransform.position, _cameraMain.transform.position);
            Ray ray = _cameraMain.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(_distance);
            _movingTransform.position = new Vector3(rayPoint.x, 2f, rayPoint.z);

            if (Input.GetMouseButtonUp(0) && _movingTransform != null)
            {
                _movingTransform = null;
                MouseReleased?.Invoke();
            }
        }
    }

}

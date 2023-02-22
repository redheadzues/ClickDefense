using System;
using UnityEngine;
using UnityEngine.UI;

public class ModeSwitcher : MonoBehaviour
{
    //[SerializeField] private Button _buttonBuildingMode;

    public bool IsBuildModeActivated { get; private set; }

    public event Action BuildingModeChanged;

    private void OnEnable()
    {
        //_buttonBuildingMode.onClick.AddListener(OnbuttonBuildingModeClick);
    }

    private void OnDisable()
    {
        //_buttonBuildingMode.onClick.RemoveListener(OnbuttonBuildingModeClick);
    }

    private void Start()
    {
        BuildingModeChanged?.Invoke();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            OnbuttonBuildingModeClick();
    }

    private void OnbuttonBuildingModeClick()
    {
        if(IsBuildModeActivated == true)
            IsBuildModeActivated = false;
        else
            IsBuildModeActivated= true;

        BuildingModeChanged?.Invoke();
    }

    // new Vector3(2.8f,18.2f,-1.8f);
}

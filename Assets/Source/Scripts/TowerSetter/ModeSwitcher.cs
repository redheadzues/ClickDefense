using System;
using UnityEngine;
using UnityEngine.UI;

public class ModeSwitcher : MonoBehaviour
{
    public bool IsBuildModeActivated { get; private set; }

    public event Action BuildingModeChanged;

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


}

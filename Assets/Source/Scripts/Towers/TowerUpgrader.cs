
using System;

public class TowerUpgrader : Tower
{
    private int _upgradePoints;

    private void OnEnable()
    {
        LevelIncreased += OnLevelIncreased;
    }

    private void OnDisable()
    {
        LevelIncreased -= OnLevelIncreased;
    }

    private void OnLevelIncreased()
    {
        _upgradePoints++;
    }

    public bool TryUpgradeRange()
    {
        if(_upgradePoints > 0)
        {
            _upgradePoints--;
            IncreaseRange(1);

            return true;
        }
        else
            return false;
    }
}

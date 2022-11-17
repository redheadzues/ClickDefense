using UnityEngine;

public class ClickDamageCalculator : MonoBehaviour
{
    [SerializeField] private PlayerLevel _playerLevel;
    [SerializeField] private CriticalStrikeCalculator _critical;

    public double GetValue()
    {
        return _playerLevel.Value * _critical.GetValue();
    }
}

using UnityEngine;

public class ClickDamageCalculator : MonoBehaviour
{
    [SerializeField] private PlayerLevel _playerLevel;

    public double GetValue()
    {
        return _playerLevel.Value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalStrikeCalculator : MonoBehaviour
{
    private float _criticalStrikeChance = 5;
    private float _criticalStrikeMultiplicator = 1.5f;

    public float GetValue()
    {
        bool isCritical = Random.Range(1, 100) <= _criticalStrikeChance;

        if (isCritical == true)
            return _criticalStrikeMultiplicator;
        else
            return 1;
    }
}

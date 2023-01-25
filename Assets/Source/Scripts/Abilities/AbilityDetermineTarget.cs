using Assets.Source.Scripts.Enemies;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityDetermineTarget : ScriptableObject
{
    public abstract List<IEnemy> GetTarget(IEnemy enemy, float distance);
}

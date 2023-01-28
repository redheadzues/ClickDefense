using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.StaticData
{
    [CreateAssetMenu(fileName = "AlitilyData", menuName = "StaticData/Ability")]
    public class AbilityStaticData : ScriptableObject
    {
        [field: SerializeField] public AbilityTargetDetermineTypeId TargetDetermineTypeId { get; private set; }
        [field: SerializeField] public int ExecutionOrder { get; private set; }
        [field: SerializeField] public List<GamePlayEffectStaticData> Effects { get; private set; }

    }
}
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.StaticData.Abilities
{
    public enum AbilityTargetDetermineTypeId
    {
        Single,
        Area,
        Chain
    }

    public enum AbilityDurationTypeId
    {
        OneTime,
        LongEffect
    }

    public enum AbilityDamageTypeId
    {
        Physical,
        Cold,
        Poison,
        Fire,
        Electric
    }

    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class AbilityStaticData : ScriptableObject
    {
        public AbilityTargetDetermineTypeId TargetDetermineTypeId;
        public AbilityDurationTypeId DurationTypeId;
        public AbilityDamageTypeId DamageTypeId;
    }
}
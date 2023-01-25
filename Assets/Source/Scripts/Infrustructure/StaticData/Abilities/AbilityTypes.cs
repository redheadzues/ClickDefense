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

    public enum AbilityAddDamageTypeId
    {
        Sum,
        Multiplication
    }

    [CreateAssetMenu(fileName = "AlitilyData", menuName = "StaticData/Ability")]
    public class AbilityStaticData : ScriptableObject
    {
        [field: SerializeField] public AbilityTargetDetermineTypeId TargetDetermineTypeId { get; private set; }
        [field: SerializeField] public AbilityDurationTypeId DurationTypeId { get; private set; }
        [field: SerializeField] public AbilityDamageTypeId DamageTypeId { get; private set; }
        [field: SerializeField] public AbilityAddDamageTypeId AddDamageTypeId { get; private set; }
        [field: SerializeField] public int ExecutionOrder { get; private set; }
        [field: SerializeField] public float Area { get; private set; }
        [field: SerializeField] public float Distance { get; private set; }
        [field: SerializeField] public float Frequency { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }

    }
}
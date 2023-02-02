using Assets.Source.Scripts.AbilitiesSystem.Attributes;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.StaticData
{
    [CreateAssetMenu(fileName = "GamePlayEffect", menuName = "StaticData/Abilities/GamePlayEffect")]
    public class GamePlayEffectStaticData : ScriptableObject
    {
        [field: SerializeField] public GamePlayEffecTypesIds DurationTypeId { get; private set; }
        [field: SerializeField] public GamePlayEffectDamageTypeId DamageTypeId { get; private set; }
        [field: SerializeField] public GameObject VFXPrefab { get; private set; }
        [field: SerializeField] public float Frequency { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
        [field: SerializeField] public int InstantDamage { get; private set; }
        [field: SerializeField] public int DamagePerPeriod{ get; private set; }
        [field: SerializeField] public GamePlayAttributesChanger AttributesChanger { get; private set; }
    }
}
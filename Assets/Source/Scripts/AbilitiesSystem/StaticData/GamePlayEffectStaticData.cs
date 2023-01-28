using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.StaticData
{
    [CreateAssetMenu(fileName = "AlitilyData", menuName = "StaticData/GamePlayEffect")]
    public class GamePlayEffectStaticData : ScriptableObject
    {
        [field: SerializeField] public GamePlayEffecTypesIds DurationTypeId { get; private set; }
        [field: SerializeField] public GamePlayEffectDamageTypeId DamageTypeId { get; private set; }
        [field: SerializeField] public GameObject VFXPrefab { get; private set; }
        [field: SerializeField] public float EffectFrequency { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.StaticData
{
    [CreateAssetMenu(fileName = "AlitilyData", menuName = "StaticData/Abilities/Ability")]
    public class AbilityStaticData : ScriptableObject
    {
        public Sprite Icon;
        public string Description;
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public AbilityTargetDetermineTypeId TargetDetermineTypeId { get;  set; }
        [field: SerializeField] public List<AbilityTag> ApplicableTags { get; private set; }
        [field: SerializeField] public List<GamePlayEffectStaticData> Effects { get; private set; }
        public float Area { get; set; }
        public GameObject projectilePrefab;

    }
}
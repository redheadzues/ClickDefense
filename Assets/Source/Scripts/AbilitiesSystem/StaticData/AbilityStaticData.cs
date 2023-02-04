using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.StaticData
{
    [CreateAssetMenu(fileName = "AlitilyData", menuName = "StaticData/Abilities/Ability")]
    public class AbilityStaticData : ScriptableObject
    {
        public Sprite Icon;
        public string Description;
        public string Name;
        public AbilityTargetDetermineTypeId TargetDetermineTypeId;
        public List<AbilityTag> ApplicableTags;
        public List<GamePlayEffectStaticData> Effects;
        public float Area { get; set; }
        public GameObject projectilePrefab;

        public string Id;

    }
}
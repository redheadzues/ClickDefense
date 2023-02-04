using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.StaticData
{
    [CreateAssetMenu(fileName = "PlayerInGameAbilities", menuName = "StaticData/Abilities/PlayerInGameAbility")]
    public class PlayerAbilitiesStaticData : ScriptableObject
    {
        public List<AbilityStaticData> AbilitiesData;

    }
}

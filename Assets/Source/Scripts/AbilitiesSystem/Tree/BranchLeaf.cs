using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Tree
{
    [Serializable]
    public class Leaf
    {
        public AbilityStaticData AbilityData;
        public List<AbilityStaticData> Requirements;
        [HideInInspector] public Vector2 UIPosition;
        public bool IsOwned;

        public Leaf(AbilityStaticData abilityData, List<AbilityStaticData> requirements, Vector2 uIPosition)
        {
            AbilityData = abilityData;
            Requirements = requirements;
            UIPosition = uIPosition;
            IsOwned = false;            
        }
    }
}

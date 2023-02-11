using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Tree
{
    [CreateAssetMenu(fileName = "AbilityTree", menuName = "StaticData/Abilities/AbilityTree/Tree")]
    public class AbilityTree : ScriptableObject
    {
        public List<Branch> _branches;
    }
}

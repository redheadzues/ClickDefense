using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Tree
{
    [CreateAssetMenu(fileName = "BranchLeaf", menuName = "StaticData/Abilities/AbilityTree/BranchLeaf")]
    public class BranchLeaf : ScriptableObject
    {
        public AbilityStaticData abilityData;
        public int Level;
    }
}

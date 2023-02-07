using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Tree
{
    [CreateAssetMenu(fileName = "Branch", menuName = "StaticData/Abilities/AbilityTree/Branch")]
    public class Branch : ScriptableObject
    {
        public List<BranchLeaf> _branchLevels;
    }
}

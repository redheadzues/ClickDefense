using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System.Collections.Generic;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class AbilityTree
    {
        public List<Branch> _branches;
    }

    public class Branch
    {
        List<BranchLevel> _branchLevels;
    }

    public class BranchLevel
    {
        public AbilityStaticData abilityData;
        public int Level;
    }
}

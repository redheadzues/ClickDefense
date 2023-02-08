using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Tree
{
    [CreateAssetMenu(fileName = "Branch", menuName = "StaticData/Abilities/AbilityTree/Branch")]
    public class Branch : ScriptableObject
    {
        public List<Leaf> Leafs;

        public void AddLeaf(AbilityStaticData abilityData, Vector2 UIPosition)
        {
            bool isContain = CheckContainInBranch(abilityData);

            if (isContain == false)
                Leafs.Add(new Leaf(abilityData, new List<Leaf>(), UIPosition));
        }

        public void RemoveLeaf(Leaf removeLeaf)
        {
            int removeIndex = FindLeafIndex(removeLeaf);

            foreach (Leaf leaf in Leafs)
            {
                if (leaf.Requirements.Contains(removeLeaf))
                    leaf.Requirements.Remove(removeLeaf);
            }

            Leafs.RemoveAt(removeIndex);
        }

        public int FindLeafIndex(Leaf leaf)
        {
            for (int i = 0; i < Leafs.Count; i++)
            {
                if (Leafs[i] == leaf)
                    return i;
            }            

            return -1;
        }

        public bool IsConnectible(int incomingLeafIndex, int outgoingLeafIndex)
        {
            if (incomingLeafIndex == outgoingLeafIndex)
                return false;

            return (DoesLeadsToInCascade(incomingLeafIndex, outgoingLeafIndex) || DoesLeadsToInCascade(outgoingLeafIndex, incomingLeafIndex)) == false;
        }

        public HashSet<Leaf> GetAllPastRequirements(int leafIndex, bool includeSelfRequirement = true)
        {
            HashSet<Leaf> allRequirements = includeSelfRequirement 
                ? new HashSet<Leaf>(Leafs[leafIndex].Requirements) 
                : new HashSet<Leaf>();

            foreach(Leaf leaf in Leafs[leafIndex].Requirements)
                allRequirements.UnionWith(GetAllPastRequirements(FindLeafIndex(leaf)));

            return allRequirements;
        }

        public void CorrectRequirementCascade(int leafIndex)
        {
            HashSet<Leaf> allConnectedThroughtChildren = GetAllPastRequirements(leafIndex, false);

            foreach(Leaf leaf in allConnectedThroughtChildren)
            {
                if (Leafs[leafIndex].Requirements.Contains(leaf))
                    Leafs[leafIndex].Requirements.Remove(leaf);
            }
        }

        public HashSet<AbilityStaticData> GetAvailableAbility()
        {
            HashSet<AbilityStaticData> availableAbility = new HashSet<AbilityStaticData>();

            foreach(Leaf leaf in Leafs)
            {
                if(CheckAvailable(leaf))
                    availableAbility.Add(leaf.AbilityData);
            }

            return availableAbility;
        }

        private bool DoesLeadsToInCascade(int queryIndex, int subjectIndex)
        {
            foreach (Leaf leaf in Leafs[queryIndex].Requirements)
            {
                if (leaf == Leafs[subjectIndex])
                    return true;

                if (DoesLeadsToInCascade(FindLeafIndex(leaf), subjectIndex))
                    return true;
            }

            return false;
        }

        private bool CheckContainInBranch(AbilityStaticData abilityData)
        {
            foreach (Leaf leaf in Leafs)
            {
                if (leaf.AbilityData == abilityData)
                    return true;
            }

            return false;
        }

        private bool CheckAvailable(Leaf leaf)
        {
            if(leaf.IsOwned)
                return false;

            foreach (Leaf requiredLeaf in leaf.Requirements)
            {
                if (requiredLeaf.IsOwned == false)
                    return false;
            }

            return true;
        }
    }
}

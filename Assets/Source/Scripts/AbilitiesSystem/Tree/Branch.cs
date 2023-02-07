using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem.Tree
{
    [CreateAssetMenu(fileName = "Branch", menuName = "StaticData/Abilities/AbilityTree/Branch")]
    public class Branch : ScriptableObject
    {
        public List<Leaf> Leafs;

        public bool AddLeaf(AbilityStaticData abilityData, Vector2 UIPosition)
        {
            int leafIndex = FindLeafIndex(abilityData);

            if (leafIndex == -1)
            {
                Leafs.Add(new Leaf(abilityData, new List<AbilityStaticData>(), UIPosition));
                return true;
            }
            else
                return false;
        }

        public void RemoveLeaf(AbilityStaticData abilityData)
        {
            int removeIndex = FindLeafIndex(abilityData);

            Leafs.RemoveAt(removeIndex);

            foreach(Leaf leaf in Leafs)
            {
                if (leaf.Requirements.Contains(abilityData))
                    leaf.Requirements.Remove(abilityData);
            }
        }

        public int FindLeafIndex(AbilityStaticData abilityData)
        {
            for (int i = 0; i < Leafs.Count; i++)
            {
                if (Leafs[i].AbilityData == abilityData)
                    return i;
            }            

            return -1;
        }

        public bool DoesLeadsToInCascade(int queryIndex, int subjectIndex)
        {
            foreach(AbilityStaticData abilityData in Leafs[queryIndex].Requirements)
            {
                if (abilityData == Leafs[subjectIndex].AbilityData)
                    return true;

                if(DoesLeadsToInCascade(FindLeafIndex(abilityData), subjectIndex)) 
                    return true;
            }

            return false;
        }

        public bool IsConnectible(int incomingLeafIndex, int outgoingLeafIndex)
        {
            if (incomingLeafIndex == outgoingLeafIndex)
                return false;

            return (DoesLeadsToInCascade(incomingLeafIndex, outgoingLeafIndex) || DoesLeadsToInCascade(outgoingLeafIndex, incomingLeafIndex)) == false;
        }

        public HashSet<AbilityStaticData> GetAllPastRequirements(int leafIndex, bool includeSelfRequirement = true)
        {
            HashSet<AbilityStaticData> allRequirements = includeSelfRequirement 
                ? new HashSet<AbilityStaticData>(Leafs[leafIndex].Requirements) 
                : new HashSet<AbilityStaticData>();

            foreach(AbilityStaticData abilityData in Leafs[leafIndex].Requirements)
                allRequirements.UnionWith(GetAllPastRequirements(FindLeafIndex(abilityData)));

            return allRequirements;
        }

        public void CorrectRequirementCascade(int leafIndex)
        {
            HashSet<AbilityStaticData> allConnectedThroughtChildren = GetAllPastRequirements(leafIndex, false);

            foreach(AbilityStaticData abilityData in allConnectedThroughtChildren)
            {
                if (Leafs[leafIndex].Requirements.Contains(abilityData))
                    Leafs[leafIndex].Requirements.Remove(abilityData);
            }
        }
    }
}

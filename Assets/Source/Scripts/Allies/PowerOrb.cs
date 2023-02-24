using Assets.Source.Scripts.MergingGrid;
using System;
using UnityEngine;

namespace Assets.Source.Scripts.Allies
{
    public class PowerOrb : MonoBehaviour, IMergeable
    {
        public Enum Type => throw new NotImplementedException();

        public int Level => throw new NotImplementedException();

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public bool Merge(IMergeable merged)
        {
            throw new NotImplementedException();
        }
    }
}

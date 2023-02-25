using Assets.Source.Scripts.MergingGrid;
using System;
using UnityEngine;

namespace Assets.Source.Scripts.Allies
{
    public class PowerOrb : MonoBehaviour, IMergeableChild
    {
        public int _level;
        private PowerOrbTypeId _powerOrbTypeId;

        public Enum Type => _powerOrbTypeId;
        public int Level => _level;

        private void Start()
        {
            _powerOrbTypeId = PowerOrbTypeId.Cold;
        }

        public void Destroy()
        {
            if(transform.parent == null)
                Destroy(gameObject);
        }

        public bool Merge(IMergeable merged)
        {
            if (merged is IMergableParent parrent)
                return parrent.Merge(this);

            if(merged is IMergeableChild)
            {
                if(Level == merged.Level && Type.Equals(merged.Type))
                {
                    _level++;
                    return true;
                }
            }

            return false;
        }

        public void SetParrent(Transform parrent)
        {
            transform.SetParent(parrent);
            transform.localPosition = Vector3.zero;
        }
    }
}

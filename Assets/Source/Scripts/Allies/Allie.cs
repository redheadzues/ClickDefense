using Assets.Source.Scripts.Infrustructure.StaticData;
using Assets.Source.Scripts.MergingGrid;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Allies
{
    public class Allie : MonoBehaviour, IMergableParent
    {
        private const int _maxChildCount = 3;
        private List<IMergeableChild> _child = new List<IMergeableChild>();
        public AllieTypeId _allieType;
        private int _level;

        public IReadOnlyList<IMergeableChild> Childs => _child;
        public Enum Type => _allieType;
        public int Level => _level;

        public void Construct(AllieTypeId type)
        {
            _allieType = type;
        }

        public void Destroy()
        {
            _child.ForEach(child => child.Destroy());
            Destroy(gameObject);
        }

        public bool Merge(IMergeable merged)
        {
            if (merged is IMergeableChild mergeableChild)
                return TryAcceptChild(mergeableChild);

            if(merged is IMergableParent mergeableParent)
            {


                if (_level == merged.Level && Type.GetType() == merged.Type.GetType())
                {
                    print("passed");

                    if(Type.CompareTo(merged.Type) == 0)
                    {
                        _level++;
                        print(_level);
                        return true;
                    }

                }
            }
            //
            //
            //
            //try MERGE CHILD TO OTHER AFTER ADD
            //
            //
            //
            return false;
        }

        private bool TryAcceptChild(IMergeableChild mergeableChild)
        {
            if (TryMergeChild(mergeableChild))
                return true;

            return TryAddChild(mergeableChild);
        }

        private bool TryAddChild(IMergeableChild mergeableChild)
        {
            if (_child.Count < _maxChildCount)
            {
                _child.Add(mergeableChild);
                return true;
            }

            return false;
        }

        private bool TryMergeChild(IMergeableChild mergeableChild)
        {
            foreach (IMergeableChild child in _child)
            {
                if (child.Merge(mergeableChild))
                    return true;
            }

            return false;
        }
    }
}

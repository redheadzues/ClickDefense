using Assets.Source.Scripts.Infrustructure.StaticData;
using Assets.Source.Scripts.MergingGrid;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Allies
{
    public class AllieMerger : MonoBehaviour, IMergableParent
    {
        private const int _maxChildCount = 3;
        private List<IMergeableChild> _children = new List<IMergeableChild>();
        public AllieTypeId _allieType;
        private int _level;

        public IReadOnlyList<IMergeableChild> Children => _children;
        public Enum Type => _allieType;
        public int Level => _level;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                print(_children.Count);
        }

        public void Construct(AllieTypeId type)
        {
            _allieType = type;
        }

        public void Destroy()
        {
            _children.ForEach(child => child.Destroy());
            Destroy(gameObject);
        }

        public bool Merge(IMergeable merged)
        {
            if (merged is IMergeableChild mergeableChild)
                return TryAcceptChild(mergeableChild);

            if(merged is IMergableParent mergeableParent)
            {
                if (_level == merged.Level && Type.Equals(merged.Type) && MergeChildren(mergeableParent, isCheckCopy: true))
                {
                    MergeChildren(mergeableParent, isCheckCopy: false);
                    _level++;
                    return true;
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

        private bool MergeChildren(IMergableParent mergeableParent, bool isCheckCopy)
        {
            List<IMergeableChild> inputChildrenCopy = mergeableParent.Children.Copy();
            List<IMergeableChild> selfChildrenCopy = _children.Copy();


            for (int inputIndex = 0; inputIndex < inputChildrenCopy.Count; inputIndex++)
            {
                for (int selfIndex = 0; selfIndex < selfChildrenCopy.Count; selfIndex++)
                {
                    if (inputChildrenCopy[inputIndex] != null)
                    {
                        if (selfChildrenCopy[selfIndex].Merge(inputChildrenCopy[inputIndex]))
                            inputChildrenCopy[inputIndex] = null;
                    }
                }
            }

            inputChildrenCopy.RemoveAll(x => x == null);

            if (selfChildrenCopy.Count + inputChildrenCopy.Count > _maxChildCount)
                return false;

            foreach (IMergeableChild inputChild in inputChildrenCopy)
                selfChildrenCopy.Add(inputChild);

            if (isCheckCopy == false)
                _children = selfChildrenCopy;

            foreach (var child in selfChildrenCopy)
                child.Destroy();

            foreach (var child in inputChildrenCopy)
                child.Destroy();

            return true;
        }

        private bool TryAcceptChild(IMergeableChild mergeableChild)
        {
            if (TryMergeChild(mergeableChild))
                return true;

            return TryAddChild(mergeableChild);
        }

        private bool TryAddChild(IMergeableChild mergeableChild)
        {
            if (_children.Count < _maxChildCount)
            {
                _children.Add(mergeableChild);
                mergeableChild.SetParrent(transform);
                return true;
            }

            return false;
        }

        private bool TryMergeChild(IMergeableChild mergeableChild)
        {
            foreach (IMergeableChild child in _children)
            {
                if (child.Merge(mergeableChild))
                {
                    mergeableChild.SetParrent(null);
                    mergeableChild.Destroy();
                    MergeSelfChild();
                    return true;
                }
            }

            return false;
        }


        private void MergeSelfChild()
        {
            while (TryMergeSelfChild()) ;
        }
        private bool TryMergeSelfChild()
        {
            for(int i = 0; i < _children.Count - 1; i++)
            {
                if (_children[i].Merge(_children[i+1]))
                {
                    RemoveChild(i+1);
                    return true;
                }
            }

            return false;
        }

        private void RemoveChild(int i)
        {
            _children[i].SetParrent(null);
            _children[i].Destroy();
            _children[i] = null;
            _children.RemoveAll(x => x == null);
        }
    }
}

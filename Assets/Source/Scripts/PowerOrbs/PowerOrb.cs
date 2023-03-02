using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using Assets.Source.Scripts.MergingGrid;
using System;
using UnityEngine;

namespace Assets.Source.Scripts.PowerOrbs
{
    public class PowerOrb : MonoBehaviour, IMergeableChild
    {
        private int _level;
        public PowerOrbTypeId _powerOrbTypeId;
        private GamePlayEffectStaticData _effectData;

        public Enum Type => _powerOrbTypeId;
        public int Level => _level;

        private void Start()
        {
            _powerOrbTypeId = PowerOrbTypeId.Cold;
        }

        public void Construct(PowerOrbTypeId typeId, GamePlayEffectStaticData effectData)
        {
            _powerOrbTypeId = typeId;
            _effectData = effectData;
        }

        public GamePlayEffectStaticData GiveEffect() => 
            _effectData;

        public void Destroy()
        {
            if (transform.parent == null)
                Destroy(gameObject);
        }

        public bool Merge(IMergeable merged)
        {
            if (merged is IMergableParent parrent)
                return false;

            if (merged is IMergeableChild)
            {
                if (Level == merged.Level && Type.Equals(merged.Type))
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

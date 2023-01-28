using Assets.Source.Scripts.AbilitiesSystem.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public abstract class Ability
    {
        protected readonly int _layerMask = 1 << LayerMask.NameToLayer("");
        protected List<GamePlayEffect> Effects;
        protected List<AbilityTag> ApplicableTags;
        protected Collider[] _hits = new Collider[20];

        public abstract void Activate(IAbilityTarget target);

        protected void GiveEffect(IAbilityTarget target)
        {
            foreach(GamePlayEffect effect in Effects)
                target.TakeEffect(effect);
        }

        protected bool CheckTargetForApply(IAbilityTarget target)
        {
            foreach (AbilityTag tag in ApplicableTags)
                if (target.Tags.Contains(tag))
                    return true;

            return false;
        }

        protected void FindTargets(Vector3 point, float distance)
        {
            Physics.OverlapSphereNonAlloc(point, distance, _hits, _layerMask);
        }
    }

    public class GamePlayEffect
    {
        public event Action<GamePlayEffect> Ended;
    }
}

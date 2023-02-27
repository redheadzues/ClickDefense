using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class EffectViewSwitcher
    {
        private Transform _parrent;
        private List<EffectViewCell> _viewCells = new List<EffectViewCell>();

        public EffectViewSwitcher(Transform transform)
        {
            _parrent = transform;
        }

        public void AddEffectView<TEffect>(TEffect effect, GameObject viewParticle) where TEffect : IEffect
        {
            GameObject view = Object.Instantiate(viewParticle, _parrent);

            if(effect is ILastingEffect lastingEffect)
            {
                lastingEffect.Ended += OnEffectEnded;

                _viewCells.Add(new EffectViewCell(lastingEffect, view));
            }
        }

        private void OnEffectEnded(ILastingEffect effect)
        {
            effect.Ended -= OnEffectEnded;  
            EffectViewCell cell = _viewCells.FirstOrDefault(x => x.Effect == effect);
            Object.Destroy(cell.ViewParticle);
            _viewCells.Remove(cell);
        }
    }
}

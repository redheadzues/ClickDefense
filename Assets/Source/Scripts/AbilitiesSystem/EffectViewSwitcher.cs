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

        public void AddEffectView(GamePlayEffect effect, GameObject viewParticle)
        {
            GameObject view = Object.Instantiate(viewParticle, _parrent);
            effect.Ended += OnEffectEnded;

            _viewCells.Add(new EffectViewCell(effect, view));
        }

        private void OnEffectEnded(GamePlayEffect effect)
        {
            EffectViewCell cell = _viewCells.FirstOrDefault(x => x.Effect == effect);
            Object.Destroy(cell.ViewParticle);
            _viewCells.Remove(cell);
        }
    }
}

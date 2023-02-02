using Assets.Source.Scripts.AbilitiesSystem;
using Assets.Source.Scripts.Enemies;
using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Infrustructure.Services.ClickListener
{
    public class ClickInformer : IClickInformer
    {
        private List<ClickReader> _clickReaders = new List<ClickReader>();

        public event Action<IDamageable> Clicked;
        public event Action<IAbilityTarget> AbilityTargetGeted;

        public void Register(ClickReader reader)
        {
            if (_clickReaders.Contains(reader) == false)
            {
                _clickReaders.Add(reader);
                reader.Clicked += OnClicked;
                reader.AbilityTargetGeted += OnTargetGeted;
            }
        }

        public void Pause()
        {
            CleanUp();
        }

        public void UnPause()
        {
            foreach (ClickReader reader in _clickReaders)
            {
                reader.Clicked += OnClicked;
                reader.AbilityTargetGeted += OnTargetGeted;
            }
        }

        public void CleanUp()
        {
            foreach (ClickReader reader in _clickReaders)
            {
                reader.Clicked -= OnClicked;
                reader.AbilityTargetGeted -= OnTargetGeted;
            }
        }

        private void OnTargetGeted(IAbilityTarget target)
        {
            AbilityTargetGeted?.Invoke(target);
        }

        private void OnClicked(IDamageable damageable)
        {
            Clicked?.Invoke(damageable);
        }
    }
}
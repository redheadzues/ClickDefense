using Assets.Source.Scripts.Enemies;
using Player;
using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Infrustructure.Services.ClickListener
{
    public class ClickInformer : IClickInformer
    {
        private List<ClickReader> _clickReaders = new List<ClickReader>();

        public event Action<IDamageable> Clicked;

        public void Register(ClickReader reader)
        {
            if (_clickReaders.Contains(reader) == false)
            {
                _clickReaders.Add(reader);
                reader.Clicked += OnClicked;
            }
        }

        public void Pause()
        {
            CleanUp();
        }

        public void UnPause()
        {
            foreach (ClickReader reader in _clickReaders)
                reader.Clicked += OnClicked;
        }

        public void CleanUp()
        {
            foreach (ClickReader reader in _clickReaders)
                reader.Clicked -= OnClicked;
        }

        private void OnClicked(IDamageable damageable)
        {
            Clicked?.Invoke(damageable);
        }
    }
}
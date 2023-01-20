using Assets.Source.Scripts.Infrustructure.Services.Progress;
using Saver;
using System;

namespace Player
{
    public class Level : ISavedPlayerSceneLevelProgress
    {
        private const int _defaultLevel = 1;

        private int _level;

        private SaverPlayerParametrs _saver;

        public event Action DataChanged;
        public int Value => _level;


        public Level()
        {
            _saver = new SaverPlayerParametrs();
            LoadSaves();
        }

        public void LoadSaves()
        {
            _level = _saver.ReadLevel(_defaultLevel);
        }

        public void IncreaseLevel()
        {
            _level++;
            _saver.WriteLevel(_level);
            NotifyAboutChange();
        }

        private void NotifyAboutChange()
        {
            DataChanged?.Invoke();
        }
    }
}
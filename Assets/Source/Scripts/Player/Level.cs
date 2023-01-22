using Assets.Source.Scripts.Infrustructure;
using Assets.Source.Scripts.Infrustructure.Services.Progress;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using Saver;
using System;

namespace Player
{
    public class Level : ISaveProgress
    {
        private const int _defaultLevel = 1;

        private int _level;

        private SaverPlayerParametrs _saver;

        public event Action DataChanged;
        public int Value => _level;


        public Level(ISaveLoadService saveLoad)
        {
            Register(saveLoad);
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

        public void Register(ISaveLoadService saveLoad)
        {
            saveLoad.Register(this);
        }

        public void SaveProgress(IProgressService progress)
        {
            progress.PlayerProgress.SceneData.PlayerLevel = _level;
        }

        public void LoadProgress(IProgressService progress)
        {
            _level = progress.PlayerProgress.SceneData.PlayerLevel;
        }
    }
}
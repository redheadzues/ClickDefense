using Assets.Source.Scripts.Infrustructure.Services.Progress;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using System;

namespace Player
{
    public class Level : ISaveProgress
    {
        private int _level;

        public event Action DataChanged;
        public int Value => _level;


        public Level(ISaveLoadService saveLoad)
        {
            Register(saveLoad);
        }

        public void IncreaseLevel()
        {
            _level++;
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
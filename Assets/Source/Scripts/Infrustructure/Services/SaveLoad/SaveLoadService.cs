using Assets.Source.Scripts.Infrustructure.Data;
using Assets.Source.Scripts.Infrustructure.Services.Progress;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Infrustructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private readonly IProgressService _progressService;

        private List<ISaveProgress> _progressSavers = new List<ISaveProgress>();

        public SaveLoadService(IProgressService progressService)
        {
            _progressService = progressService;
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
        }

        public void SaveProgress()
        {
            foreach (ISaveProgress saver in _progressSavers)
                saver.SaveProgress(_progressService);

            PlayerPrefs.SetString(ProgressKey, _progressService.PlayerProgress.ToJson());
        }

        public void PushLoadedDataToSavers()
        {
            foreach (ISaveProgress saver in _progressSavers)
                saver.LoadProgress(_progressService);
        }


        public void Register(ISaveProgress saver)
        {
            _progressSavers.Add(saver);
        }

        public void CleanUp()
        {
            _progressSavers.Clear();
        }
    }
}
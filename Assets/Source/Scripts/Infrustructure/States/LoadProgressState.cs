using Assets.Source.Scripts.Infrustructure.Data;
using Assets.Source.Scripts.Infrustructure.Services.Progress;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using System;

namespace Assets.Source.Scripts.Infrustructure.States
{
    internal class LoadProgressState : ISimpleState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IProgressService _progress;
        private ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IProgressService progress, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progress = progress;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<LoadLevelState, string>(_progress.PlayerProgress.GlobalData.SceneName);
        }

        public void Exit()
        {
            
        }


        private void LoadProgressOrInitNew()
        {
            _progress.PlayerProgress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            return new PlayerProgress(initialLevel: "Main");
        }
    }
}
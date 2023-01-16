﻿namespace Assets.Source.Scripts.Infrustructure.States
{
    public class LoadLevelState : IState
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load("MainScene");
        }

        public void Exit()
        {
        }
    }
}
using Assets.Source.Scripts.Infrustructure.States;
using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Infrustructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(TState)];
            state.Enter();
            _activeState = state;
        }        
    }
}
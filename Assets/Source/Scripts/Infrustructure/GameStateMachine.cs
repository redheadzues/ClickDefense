using Assets.Source.Scripts.Infrustructure.Services;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.Services.Progress;
using Assets.Source.Scripts.Infrustructure.Services.Reward;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.Infrustructure.Services.Wallets;
using Assets.Source.Scripts.Infrustructure.States;
using System;
using System.Collections.Generic;

namespace Assets.Source.Scripts.Infrustructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services, Curtain curtain, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services, coroutineRunner),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain),
                [typeof(LoadProgressState)] = new LoadProgressState(this, services.Single<IProgressService>(), services.Single<ISaveLoadService>()),
                [typeof(SceneConstructState)] = new SceneConstructState(
                    this,
                    services.Single<IUIFactory>(),
                    curtain,
                    services.Single<ISaveLoadService>(),
                    services.Single<IWalletHolder>().SilverWallet,
                    services.Single<IStaticDataService>(),
                    services.Single<ICoroutineRunner>(),
                    services.Single<IRewarder>())
                    
            };
        }

        public void Enter<TState>() where TState : class, ISimpleState
        {
            ISimpleState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payload) where TState : class,  IPayLoadedState<TPayLoad>
        {
            IPayLoadedState<TPayLoad> state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}
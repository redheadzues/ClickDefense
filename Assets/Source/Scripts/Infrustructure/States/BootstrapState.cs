using Assets.Source.Scripts.Infrustructure.Services;
using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Factories;

namespace Assets.Source.Scripts.Infrustructure.States
{
    internal class BootstrapState : ISimpleState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load("Init", OnLevelLoaded);
        }

        public void Exit()
        {
        }
        
        private void OnLevelLoaded()
        {
            _gameStateMachine.Enter<LoadLevelState, string>("Main");
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IPlayerModel>(new PlayerModel());
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IAssetProvider>(), _services.Single<IPlayerModel>()));
            _services.RegisterSingle<IClickListener>(new ClickListener(_services.Single<IPlayerModel>().DamageCalculator));
            _services.RegisterSingle<IEnemyFactory>(new EnemyFactory(_services.Single<IAssetProvider>(), _services.Single<IClickListener>()));
        }
    }
}
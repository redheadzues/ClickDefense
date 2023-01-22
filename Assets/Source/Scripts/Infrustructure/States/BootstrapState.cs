using Assets.Source.Scripts.Infrustructure.Services;
using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.Services.Progress;
using Assets.Source.Scripts.Infrustructure.Services.Reward;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.Infrustructure.Services.Wallets;

namespace Assets.Source.Scripts.Infrustructure.States
{
    internal class BootstrapState : ISimpleState
    {
        private const string InitialSceneName = "Init";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            _coroutineRunner = coroutineRunner;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialSceneName, OnLevelLoaded);
        }

        public void Exit()
        {
        }
        
        private void OnLevelLoaded()
        {
            _gameStateMachine.Enter<LoadProgressState>();
        }

        private void RegisterServices()
        {
            RegisterStaticData();

            _services.RegisterSingle(_coroutineRunner);
            _services.RegisterSingle<IProgressService>(new ProgressService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IProgressService>()));
            _services.RegisterSingle<IWalletHolder>(new WalletHolder(_services.Single<ISaveLoadService>()));
            _services.RegisterSingle<IRewarder>(new Rewarder(_services.Single<IWalletHolder>()));
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IClickInformer>(new ClickInformer());
            _services.RegisterSingle<IEnemyFactory>(new EnemyFactory(_services.Single<IClickInformer>(), _services.Single<IRewarder>(), _services.Single<IStaticDataService>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }
    }
}
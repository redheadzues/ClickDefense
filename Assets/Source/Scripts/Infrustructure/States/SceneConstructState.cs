using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.Player;
using Money;

namespace Assets.Source.Scripts.Infrustructure.States
{
    public class SceneConstructState : ISimpleState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ISaveLoadService _saveload;
        private readonly Curtain _curtain;
        private readonly SilverWallet _silverWallet;
        private readonly IClickInformer _clickInformer;
        private readonly IStaticDataService _staticData;
        private readonly ICoroutineRunner _coroutineRunner;
        private PlayerModel _player;

        public SceneConstructState(
            GameStateMachine gameStateMachine,
            IUIFactory uiFactory,
            Curtain curtain,
            IEnemyFactory enemyFactory,
            ISaveLoadService saveLoad,
            SilverWallet silverWallet,
            IClickInformer clickInformer,
            IStaticDataService staticData,
            ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _curtain = curtain;
            _enemyFactory = enemyFactory;
            _saveload = saveLoad;
            _silverWallet = silverWallet;
            _clickInformer = clickInformer;
            _staticData = staticData;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter()
        {
            CreatePlayer();

            EnemySpawner spawner = new EnemySpawner(_enemyFactory, _staticData, _coroutineRunner);
            Vawe vawe = new Vawe(spawner, _saveload);

            CreateUI();

            LoadSceneData();

            _curtain.Hide();
        }



        private void CreateUI()
        {
            _uiFactory.CreateHud(_player);
        }

        public void Exit()
        {
        }
        private void CreatePlayer()
        {
            _player = new PlayerModel(_saveload, _silverWallet, _clickInformer);
        }

        private void LoadSceneData()
        {
            _saveload.PushLoadedDataToSavers();
        }               
    }
}
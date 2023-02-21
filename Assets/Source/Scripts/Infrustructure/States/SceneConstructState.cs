using Assets.Source.Scripts.AbilitiesSystem.Abilities;
using Assets.Source.Scripts.AbilitiesSystem.Factories;
using Assets.Source.Scripts.AbilitiesSystem.Tree;
using Assets.Source.Scripts.GameOver;
using Assets.Source.Scripts.Infrustructure.Services.AssetManagment;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.Factories;
using Assets.Source.Scripts.Infrustructure.Services.Reward;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using Assets.Source.Scripts.Infrustructure.Services.StaticData;
using Assets.Source.Scripts.Player;
using Assets.Source.Scripts.Shops;
using Money;

namespace Assets.Source.Scripts.Infrustructure.States
{
    public class SceneConstructState : ISimpleState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUIFactory _uiFactory;
        private readonly ISaveLoadService _saveload;
        private readonly Curtain _curtain;
        private readonly SilverWallet _silverWallet;
        private readonly IStaticDataService _staticData;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IAbilityFactory _abilityFactory;
        private readonly IRewarder _rewarder;
        private readonly IAssetProvider _assetProvider;

        private ICharacterFactory _characterFactory;
        private IClickInformer _clickInformer;
        private PlayerModel _player;
        private Vawe _vawe;
        private PlayerAbilityRewarder _playerAbilityRewarder;
        private LivesCounter _counter;
        private GameOverer _gameOverer;

        public SceneConstructState(
            GameStateMachine gameStateMachine,
            IUIFactory uiFactory,
            Curtain curtain,
            ISaveLoadService saveLoad,
            SilverWallet silverWallet,
            IStaticDataService staticData,
            ICoroutineRunner coroutineRunner,
            IRewarder rewarder,
            IAbilityFactory abilityFactory,
            IAssetProvider assetProvider)
        {
            _gameStateMachine = gameStateMachine;
            _uiFactory = uiFactory;
            _curtain = curtain;
            _saveload = saveLoad;
            _silverWallet = silverWallet;
            _staticData = staticData;
            _coroutineRunner = coroutineRunner;
            _abilityFactory = abilityFactory;
            _rewarder = rewarder;
            _abilityFactory = abilityFactory;
            _assetProvider = assetProvider;
        }

        public void Enter()
        {
            CreateClickInformer();
            CreatePlayer();
            CreateEnemySpawner();
            CreateUI();
            CreateAbilityRewarder();
            CreateGameOverLogic();
            LoadSceneData();

            _curtain.Hide();
        }

        private void CreateGameOverLogic()
        {
            _counter = new LivesCounter(3);
            EnemyTrigger enemyTrigger = _assetProvider.Instantiate("EnemyTrigger").GetComponent<EnemyTrigger>();
            enemyTrigger.Construct(_counter);
            _gameOverer = new GameOverer(_counter);
        }

        private void CreateClickInformer()
        {
            _clickInformer = new ClickInformer();
        }

        private void CreateAbilityRewarder()
        {
            Branch playerAbilityData = _staticData.ForPlayerAbility();
            _playerAbilityRewarder = new PlayerAbilityRewarder(playerAbilityData, _abilityFactory, _player.AbilityContainer, _vawe, _uiFactory);
        }

        private void CreateEnemySpawner()
        {
            _characterFactory = new CharacterFactory(_clickInformer, _rewarder, _staticData);
            EnemySpawner spawwner = new(_characterFactory, _staticData, _coroutineRunner);
            _vawe = new Vawe(spawwner, _saveload);
        }

        private void CreateUI()
        {
            _uiFactory.CreateRootCanvas();
            _uiFactory.CreateHud(_player, _silverWallet, _vawe, _characterFactory);
        }

        public void Exit()
        {
        }

        private void CreatePlayer()
        {
            Ability ability = _abilityFactory.Create("a4cfbe1c-4be6-4dc0-8e90-f1085e7feb5411-42-32-04-42-2023-42");
            _player = new PlayerModel(_saveload, _clickInformer);
            _player.AbilityContainer.AddAbility(ability);
        }

        private void LoadSceneData()
        {
            _saveload.PushLoadedDataToSavers();
        }               
    }
}
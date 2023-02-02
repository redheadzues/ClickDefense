using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Assets.Source.Scripts.Infrustructure.Services.SaveLoad;
using Money;
using Player;

namespace Assets.Source.Scripts.Player
{
    public class PlayerModel
    {
        private readonly Level _level;
        private readonly DamageCalculator _damageCalculator;
        private readonly CostCalculator _costCalculator;
        private readonly DamageDealer _playerDamageDealer;
        private readonly AbilityContainer _abilityContainer;
        private readonly AbilityApplyer _playerAbilityApplyer;

        public Level Level => _level;
        public DamageCalculator DamageCalculator => _damageCalculator;
        public CostCalculator Cost => _costCalculator;
        public AbilityContainer AbilityContainer => _abilityContainer;

        public PlayerModel(ISaveLoadService saveLoad, IClickInformer clickInformer)
        {
            _level = new Level(saveLoad);
            _damageCalculator = new DamageCalculator(_level);
            _costCalculator = new CostCalculator(_level);
            _playerDamageDealer = new DamageDealer(clickInformer, _damageCalculator);
            _abilityContainer = new AbilityContainer();
            _playerAbilityApplyer = new AbilityApplyer(_abilityContainer, clickInformer);
        }
    }
}

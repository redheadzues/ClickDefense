using UnityEngine;

namespace Player
{
    public class PlayerModel : MonoBehaviour
    {
        private Wallet _wallet;
        private Parametrs _playerParametrs;
        private DamageCalculator _damageCalculator;
        private CostCalculator _costCalculator;
        private Upgrader _upgrader;


        public IWallet Wallet => _wallet;
        public IDataChangedNotifyer Parametrs => _playerParametrs;
        public IPlayerDamage Damage => _damageCalculator;
        public IPlayerCalculatedCost Cost => _costCalculator;
        public IPlayerUpgrader Upgrader => _upgrader;

        public void Awake()
        {
            _wallet = new Wallet();
            _playerParametrs = new Parametrs();
            _damageCalculator = new DamageCalculator(_playerParametrs, _playerParametrs);
            _costCalculator = new CostCalculator(_playerParametrs);
            _upgrader = new Upgrader(_playerParametrs, _costCalculator, _wallet);
        }
    }
}
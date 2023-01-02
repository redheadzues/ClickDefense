using NumbersForIdle;

namespace Player
{
    public class Upgrader : IPlayerUpgrader
    {
        private IPlayerUpgrader _upgrader;
        private IPlayerCalculatedCost _calculatedData;
        private IWallet _wallet;

        public Upgrader(IPlayerUpgrader upgrader, IPlayerCalculatedCost calculatedData, IWallet wallet)
        {
            _upgrader = upgrader;
            _calculatedData = calculatedData;
        }

        public void IncreaseCriticalChance(float value)
        {
            //if(_wallet.TrySpendMoney(_calculatedData.GetValue()))
               // _upgrader.IncreaseCriticalChance(value);
        }

        public void IncreaseCriticalMultiplicator(float value)
        {
            throw new System.NotImplementedException();
        }

        public void IncreaseLevel()
        {
            if(_wallet.TrySpendMoney(_calculatedData.GetValue()))
                _upgrader.IncreaseLevel();
        }
    }
}

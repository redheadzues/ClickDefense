using Money;
using Player;

namespace Assets.Source.Scripts.Infrustructure.Services
{
    public interface IPlayerModel : IService
    {
        Parametrs Parametrs { get; }
        DamageCalculator DamageCalculator { get; }
        CostCalculator Cost { get; }
        SilverWallet SilverWallet { get; }
    }
}
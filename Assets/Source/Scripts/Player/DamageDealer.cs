using Assets.Source.Scripts.Enemies;
using Assets.Source.Scripts.Infrustructure.Services.ClickListener;
using Player;

namespace Assets.Source.Scripts.Player
{
    public class DamageDealer
    {
        private readonly IClickInformer _clickInformer;
        private readonly DamageCalculator _damageCalculator;

        public DamageDealer(IClickInformer clickInformer, DamageCalculator damageCalculator)
        {
            _clickInformer = clickInformer;
            _damageCalculator = damageCalculator;

            _clickInformer.Clicked += OnClicked;
        }

        private void OnClicked(IDamageable damageable)
        {
            damageable.TakeDamage(_damageCalculator.GetValue());
        }
    }
}

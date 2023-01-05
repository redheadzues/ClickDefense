using NumbersForIdle;

namespace Player
{
    public class DamageCalculator
    {
        private const int _percent = 100;

        private Parametrs _parametrs;

        public DamageCalculator(Parametrs parametrs)
        {
            _parametrs = parametrs;
        }

        public IdleNumber GetPureValue()
        {
            IdleNumber damage = new(_parametrs.Level);

            return damage;
        }

        public IdleNumber GetValue()
        {
            IdleNumber damage = GetPureValue() * GetCriticalStrike();

            return damage;
        }

        private float GetCriticalStrike()
        {
            if (_parametrs.CriticalChance >= RandomFloat.Next(0, _percent))
                return _parametrs.CriticalMultiplicator;
            else
                return 1;
        }
    }
}

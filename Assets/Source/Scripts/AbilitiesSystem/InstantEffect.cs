namespace Assets.Source.Scripts.AbilitiesSystem
{
    public class InstantEffect : IInstantEffect
    {
        private readonly int _instantDamage;

        public int InstantDamage => _instantDamage;

        public InstantEffect(int instantDamage)
        {
            _instantDamage = instantDamage;
        }

        public void Abort()
        {
        }
    }
}

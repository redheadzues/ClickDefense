namespace Assets.Source.Scripts.AbilitiesSystem.Attributes
{
    public struct GamePlayAttributes
    {
        public float Speed;
        public float Damage;
        public float Range;
        public float AttackSpeed;

        public GamePlayAttributes(float speed = 0, float damage = 0, float range = 0, float attackSpeed = 0)
        {
            Speed = speed;
            Damage = damage;
            Range = range;
            AttackSpeed = attackSpeed;
        }

        public GamePlayAttributes ChangeAttributes(GamePlayAttributesChanger changer)
        {
            float speed = Speed * changer.Speed;
            float damage = Damage * changer.Damage;
            float range = Range * changer.Range;
            float attackSpeed = AttackSpeed * changer.AttackSpeed;


            return new GamePlayAttributes(speed, damage, range, attackSpeed);
        }
    }
}

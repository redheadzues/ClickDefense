using Assets.Source.Scripts.Infrustructure;
using System;

namespace Assets.Source.Scripts.AbilitiesSystem.Attributes
{
    [Serializable]
    public struct GamePlayAttributesChanger
    {
        public float Speed;
        public float Damage;
        public float Range;
        public float AttackSpeed;

        private const int c_Percent = 100;

        public GamePlayAttributesChanger(float speed, float damage, float range, float attackSpeed)
        {
            Speed = GetFloatPercentageRepresentation(speed);
            Damage = GetFloatPercentageRepresentation(damage);
            Range = GetFloatPercentageRepresentation(range);
            AttackSpeed = GetFloatPercentageRepresentation(attackSpeed);
        }

        public static GamePlayAttributesChanger operator *(GamePlayAttributesChanger firstChanger, GamePlayAttributesChanger secondChanger)
        {
            float speed = firstChanger.Speed * secondChanger.Speed;
            float damage = firstChanger.Damage * secondChanger.Damage;
            float range = firstChanger.Range * secondChanger.Range;
            float attackSpeed = firstChanger.AttackSpeed * secondChanger.AttackSpeed;

            return new GamePlayAttributesChanger(speed, damage, range, attackSpeed);
        }

        private static float GetFloatPercentageRepresentation(float value)
        {

            return 1 + value / c_Percent;
        }
    }
}

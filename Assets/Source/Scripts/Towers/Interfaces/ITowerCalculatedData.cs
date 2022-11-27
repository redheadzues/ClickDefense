public interface ITowerCalculatedData
{
    float CurrentRange { get; }
    float CurrentAttackRate { get; }
    double CurrentDamage { get; }

    double CurrentUpgradeCost { get; }
}

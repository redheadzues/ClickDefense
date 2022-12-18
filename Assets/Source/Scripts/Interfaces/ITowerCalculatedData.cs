using NumbersForIdle;
public interface ITowerCalculatedData
{
    float CurrentRange { get; }
    float CurrentAttackRate { get; }
    IdleNumber CurrentDamage { get; }
    IdleNumber CurrentUpgradeCost { get; }
}

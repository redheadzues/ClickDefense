using GameLevel;
using NumbersForIdle;
using UnityEngine;

public class GameLevelUnity : MonoBehaviour, IGetEnemyHealth, IGameLevel
{
    private Level _level;
    private EnemyHealthCalculator _enemyHealthCalculator;

    public int Number => _level.Value;
    public IdleNumber EnemyHealthValue => _enemyHealthCalculator.GetValue();

    private void Awake()
    {
        _level = new Level();
        _enemyHealthCalculator = new EnemyHealthCalculator(_level);
    }

    public void Increase()
    {
        _level.Increase();
    }
}

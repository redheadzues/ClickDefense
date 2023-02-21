using Assets.Source.Scripts.GameOver;
using Assets.Source.Scripts.Player;
using Money;
using TMPro;
using UnityEngine;

public class UIHud : MonoBehaviour
{
    [SerializeField] private TMP_Text _textBalance;
    [SerializeField] private TMP_Text _textDamage;
    [SerializeField] private TMP_Text _textVawe;
    [SerializeField] private TMP_Text _textLives;

    private PlayerModel _player;
    private Vawe _vawe;
    private SilverWallet _wallet;
    private LivesCounter _counter;

    public void Construct(PlayerModel player, SilverWallet wallet, Vawe vawe, LivesCounter counter)
    {
        _player = player;
        _vawe = vawe;
        _wallet = wallet;
        _counter = counter;

        _player.Level.DataChanged += OnPlayerDataChanged;
        _wallet.BalanceChanged += OnBalanceChaged;
        _vawe.Started += OnStartedVawe;
        _counter.Changed += OnLivesChanged;
        UpdateData();
    }

    private void OnLivesChanged(int count)
    {
        _textLives.text = count + "жизней осталось";
    }

    private void OnDisable()
    {
        _wallet.BalanceChanged -= OnBalanceChaged;
        _player.Level.DataChanged -= OnPlayerDataChanged;
        _vawe.Started -= OnStartedVawe;
        _counter.Changed -= OnLivesChanged;
    }

    private void UpdateData()
    {
        _textVawe.text = _vawe.Number.ToString();
        _textDamage.text = _player.DamageCalculator.GetValue().ToString();
        _textBalance.text = _wallet.Balance.ToString();
        _textLives.text = _counter.Lives.ToString();
    }

    private void OnStartedVawe(int number)
    {
        _textVawe.text = number.ToString();
    }

    private void OnPlayerDataChanged()
    {
        _textDamage.text = _player.DamageCalculator.GetValue().ToString();
    }

    private void OnBalanceChaged(int balance)
    {
        _textBalance.text = balance.ToString();
    }
}

using Assets.Source.Scripts.Player;
using Money;
using TMPro;
using UnityEngine;

public class UIHud : MonoBehaviour
{
    [SerializeField] private TMP_Text _textBalance;
    [SerializeField] private TMP_Text _textDamage;
    [SerializeField] private TMP_Text _textVawe;

    private PlayerModel _player;
    private Vawe _vawe;
    private SilverWallet _wallet;

    public void Construct(PlayerModel player, SilverWallet wallet, Vawe vawe)
    {
        _player = player;
        _vawe = vawe;
        _wallet = wallet;

        _player.Level.DataChanged += OnPlayerDataChanged;
        _wallet.BalanceChanged += OnBalanceChaged;
        _vawe.Started += OnStartedVawe;
        UpdateData();
    }

    private void OnDisable()
    {
        _wallet.BalanceChanged -= OnBalanceChaged;
        _player.Level.DataChanged -= OnPlayerDataChanged;
        _vawe.Started -= OnStartedVawe;
    }

    private void UpdateData()
    {
        _textVawe.text = _vawe.Number.ToString();
        _textDamage.text = _player.DamageCalculator.GetValue().ToString();
        _textBalance.text = _wallet.Balance.ToString();
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

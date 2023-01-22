using Assets.Source.Scripts.Player;
using TMPro;
using UnityEngine;

public class UIHud : MonoBehaviour
{
    [SerializeField] private Vawe _vawe;

    [SerializeField] private TMP_Text _textBalance;
    [SerializeField] private TMP_Text _textDamage;
    [SerializeField] private TMP_Text _textVawe;

    private PlayerModel _player;

    public void Construct(PlayerModel player)
    {
        _player = player;

        _player.Level.DataChanged += OnPlayerDataChanged;
        _player.SilverWallet.BalanceChanged += OnBalanceChaged;
        UpdateData();
    }

    private void OnEnable()
    {
        //_vawe.Started += OnStartedVawe;
    }


    private void OnDisable()
    {
        
        _player.SilverWallet.BalanceChanged -= OnBalanceChaged;
        _player.Level.DataChanged -= OnPlayerDataChanged;
        //_vawe.Started -= OnStartedVawe;
    }

    private void UpdateData()
    {
        //_textVawe.text = _vawe.Number.ToString();
        _textDamage.text = _player.DamageCalculator.GetValue().ToString();
        _textBalance.text = _player.SilverWallet.Balance.ToString();
    }

    private void OnStartedVawe()
    {
        //_textVawe.text = _vawe.Number.ToString();
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

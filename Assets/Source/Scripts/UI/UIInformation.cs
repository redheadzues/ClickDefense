using UnityEngine;
using Money;
using TMPro;
using NumbersForIdle;

public class UIInformation : MonoBehaviour
{
    [Header("Data Components")]
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerUnity _player;
    [SerializeField] private Vawe _vawe;

    [Header("UI View Text")]
    [SerializeField] private TMP_Text _textBalance;
    [SerializeField] private TMP_Text _textDamage;
    [SerializeField] private TMP_Text _textVawe;

    private void OnEnable()
    {
        _wallet.BalanceChanged += OnBalanceChaged;
        _player.Parametrs.DataChanged += OnPlayerDataChanged;
        _vawe.Started += OnStartedVawe;
    }

    private void OnDisable()
    {
        _wallet.BalanceChanged -= OnBalanceChaged;
        _player.Parametrs.DataChanged -= OnPlayerDataChanged;
        _vawe.Started -= OnStartedVawe;
    }

    private void OnStartedVawe()
    {
        _textVawe.text = _vawe.Number.ToString();
    }

    private void OnPlayerDataChanged()
    {
        _textDamage.text = _player.Damage.ToString();
    }

    private void OnBalanceChaged(IdleNumber balance)
    {
        _textBalance.text = balance.ToString();
    }
}

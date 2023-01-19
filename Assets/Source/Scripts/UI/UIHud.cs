using Assets.Source.Scripts.Infrustructure.Services;
using NumbersForIdle;
using TMPro;
using UnityEngine;

public class UIHud : MonoBehaviour
{
    [SerializeField] private Vawe _vawe;

    [Header("UI View Text")]
    [SerializeField] private TMP_Text _textBalance;
    [SerializeField] private TMP_Text _textDamage;
    [SerializeField] private TMP_Text _textVawe;

    private IPlayerModel _player;

    public void Construct(IPlayerModel player)
    {
        _player = player;

        _player.Parametrs.DataChanged += OnPlayerDataChanged;
        _player.SilverWallet.BalanceChanged += OnBalanceChaged;
    }

    private void OnEnable()
    {
        _vawe.Started += OnStartedVawe;
    }


    private void OnDisable()
    {
        _player.SilverWallet.BalanceChanged -= OnBalanceChaged;
        _player.Parametrs.DataChanged -= OnPlayerDataChanged;
        _vawe.Started -= OnStartedVawe;
    }

    private void Start()
    {
        _textVawe.text = _vawe.Number.ToString();
        _textDamage.text = _player.DamageCalculator.GetValue().ToString();
        _textBalance.text = _player.SilverWallet.Balance.ToString();
    }

    private void OnStartedVawe()
    {
        _textVawe.text = _vawe.Number.ToString();
    }

    private void OnPlayerDataChanged()
    {
        _textDamage.text = _player.DamageCalculator.GetValue().ToString();
    }

    private void OnBalanceChaged(IdleNumber balance)
    {
        _textBalance.text = balance.ToString();
    }
}

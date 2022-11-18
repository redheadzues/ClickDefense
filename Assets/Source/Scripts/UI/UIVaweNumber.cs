using TMPro;
using UnityEngine;

public class UIVaweNumber : MonoBehaviour
{
    [SerializeField] private VaweCounter _vaweCounter;
    [SerializeField] private TMP_Text _textVaweNumber;

    private void OnEnable()
    {
        _vaweCounter.VaweStarted += OnVaweStarted;
    }

    private void OnDisable()
    {
        _vaweCounter.VaweStarted -= OnVaweStarted;
    }

    private void OnVaweStarted()
    {
        _textVaweNumber.text = "Волна № " + _vaweCounter.Number.ToString();
    }
}

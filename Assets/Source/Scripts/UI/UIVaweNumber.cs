using TMPro;
using UnityEngine;

public class UIVaweNumber : MonoBehaviour
{
    [SerializeField] private Vawe _vaweCounter;
    [SerializeField] private TMP_Text _textVaweNumber;

    private void OnEnable()
    {
        _vaweCounter.Started += OnVaweStarted;
    }

    private void OnDisable()
    {
        _vaweCounter.Started -= OnVaweStarted;
    }

    private void OnVaweStarted()
    {
        //_textVaweNumber.text = "Волна № " + _vaweCounter.Number.ToString();
    }
}

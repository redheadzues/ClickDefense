using UnityEngine;
using UnityEngine.UI;

public class UIButtonNextVawe : MonoBehaviour
{
    [SerializeField] private Button _buttonNextVawe;
    
    private Vawe _vawe;

    private void OnEnable()
    {
        print(_buttonNextVawe);
        _buttonNextVawe.onClick.AddListener(OnButtonNextVaweClicked);
    }

    private void OnDisable()
    {
        _buttonNextVawe.onClick.AddListener(OnButtonNextVaweClicked);
        _vawe.Finished -= OnVaweFinished;
    }

    public void Click()
    {
        print("click");
    }

    public void Construct(Vawe vawe)
    {
        _vawe = vawe;
        _vawe.Finished += OnVaweFinished;
    }

    private void OnVaweFinished()
    {
        _buttonNextVawe.gameObject.SetActive(true);
    }

    private void OnButtonNextVaweClicked()
    {
        print("Clicked");
        _vawe.StartNewVawe();
        _buttonNextVawe.gameObject.SetActive(false);
    }
}

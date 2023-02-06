using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCard : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;

    private string _id;

    public event Action<string> Selected;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonclicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonclicked);
    }

    public void SetData(Sprite icon, string name, string description, string id)
    {
        _icon.sprite = icon;
        _name.text = name;
        _description.text = description;
        _id = id;
    }

    private void OnButtonclicked()
    {
        Selected?.Invoke(_id);
    }
}

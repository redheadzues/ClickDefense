using System;
using UnityEngine;
using Saver;

public class PlayerLevel : MonoBehaviour
{
    private SaverPlayerLevel _saverLevel = new SaverPlayerLevel();
    private int _value;

    public int Value => _value;
    public event Action Increased;

    private void Awake()
    {
        _value = _saverLevel.ReadValue();
    }

    private void Start()
    {
        Increased?.Invoke();
    }

    public void Increase()
    {
        _value++;
        _saverLevel.WtiteValue(_value);
        Increased?.Invoke();
    }
}
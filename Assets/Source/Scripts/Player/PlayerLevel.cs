using System;
using UnityEngine;
using PlayerLevelSaver;

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

namespace PlayerLevelSaver
{   
    public class SaverPlayerLevel : Saver
    {
        private const string _keyLevel = "SavedPlayerLevel";
        private const int _defaultPlayerLevel = 1;

        public void WtiteValue(int level)
        {
            SetInt(_keyLevel, level);
        }

        public int ReadValue()
        {
            return GetInt(_keyLevel, _defaultPlayerLevel);
        }
    }
}

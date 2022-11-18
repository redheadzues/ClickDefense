using System;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    private int _value = 1;

    public int Value => _value;
    public event Action Increased;

    public void Increase()
    {
        _value++;
        Increased?.Invoke();
    }
}

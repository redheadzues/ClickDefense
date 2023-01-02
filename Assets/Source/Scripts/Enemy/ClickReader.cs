using System;
using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class ClickReader : MonoBehaviour
{
    private IDamageable _damageable;

    public event Action<IDamageable> Clicked;

    private void Awake()
    {
        _damageable = GetComponent<IDamageable>();
        FindObjectOfType<ClickListener>().Add(this);
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke(_damageable);
    }
}

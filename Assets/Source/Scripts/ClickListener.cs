using System;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
    [SerializeField] private PlayerUnity _playerModel;

    private List<ClickReader> _clickReaders = new List<ClickReader>();

    private void OnDisable()
    {
        foreach (ClickReader reader in _clickReaders)
            reader.Clicked -= OnClicked;
    }

    public void Add(ClickReader reader)
    {
        if (_clickReaders.Contains(reader) == false)
        {
            _clickReaders.Add(reader);
            reader.Clicked += OnClicked;
        }
    }

    private void OnClicked(IDamageable damageable)
    {
        damageable.TakeDamage(_playerModel.Damage);
    }
}

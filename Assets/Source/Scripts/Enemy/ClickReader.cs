using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class ClickReader : MonoBehaviour
{
    private IDamageable _damageable;
    private ClickDamageCalculator _clickDamage;

    private void Awake()
    {
        _damageable = GetComponent<IDamageable>();
    }

    private void OnEnable()
    {
        if(_clickDamage == null)
            _clickDamage = FindObjectOfType<ClickDamageCalculator>();
    }

    private void OnMouseDown()
    {
        _damageable.TakeDamage(_clickDamage.GetValue());
    }
}

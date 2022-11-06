using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class ClickReader : MonoBehaviour
{
    private IDamageable _damageable;

    private void Awake()
    {
        _damageable = GetComponent<IDamageable>();
    }

    private void OnMouseDown()
    {
        _damageable.TakeDamage(1);
    }
}

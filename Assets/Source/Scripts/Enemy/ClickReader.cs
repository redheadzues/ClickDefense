using UnityEngine;

public class ClickReader : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;

    private void OnMouseDown()
    {
        _health.TakeDamage(1);
    }
}

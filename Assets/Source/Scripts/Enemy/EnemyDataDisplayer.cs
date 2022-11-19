using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class EnemyDataDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _textHealth;

    private IDamageable _damageable;

    private void Awake()
    {
        _damageable = GetComponent<IDamageable>();
    }

    private void OnEnable()
    {
        _damageable.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _damageable.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged(double health)
    {
        _textHealth.text = health.ToString();
    }

    private IEnumerator RotateToPlayer()
    {
        yield return new WaitForSeconds(0.5f);

        while (_textHealth.gameObject.transform.rotation != Quaternion.LookRotation(Vector3.forward, Vector3.up))
        {
            print("coroutine");

            _textHealth.gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            yield return new WaitForSeconds(2f);
        }
    }
}

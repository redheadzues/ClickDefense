using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public class EnemyDataDisplayer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textHealth;
        [SerializeField] private Enemy _health;

        private void OnEnable()
        {
            _health.HealthChanged += OnValueChanged;
        }

        private void OnDisable()
        {
            _health.HealthChanged += OnValueChanged;
        }

        private void OnValueChanged(int health)
        {
            _textHealth.text = health.ToString();
        }

        private IEnumerator RotateToPlayer()
        {
            yield return new WaitForSeconds(0.5f);

            while (_textHealth.gameObject.transform.rotation != Quaternion.LookRotation(Vector3.forward, Vector3.up))
            {
                _textHealth.gameObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
                yield return new WaitForSeconds(2f);
            }
        }
    }
}
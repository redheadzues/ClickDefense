using System;
using UnityEngine;

namespace Assets.Source.Scripts.Enemies
{
    public class ClickReader : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;

        public event Action<IDamageable> Clicked;

        private void OnMouseDown()
        {
            Clicked?.Invoke(_enemy);
        }
    }
}
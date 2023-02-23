﻿using Assets.Source.Scripts.MergingGrid;
using UnityEngine;

namespace Assets.Source.Scripts.Allies
{
    public class Allie : MonoBehaviour, IMergeable
    {
        private int _level;

        public int Level => _level;

        public void Destroy()
        {
            Destroy(gameObject);
        }
        public void Merge()
        {
            _level++;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}

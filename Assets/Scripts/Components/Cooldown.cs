using UnityEngine;
using System;

namespace Scripts.Components
{
    [Serializable]
    public class Cooldown
    {
        [SerializeField] public float _value;

        private float _timesUP;
        public void Reset()
        {
            _timesUP = Time.time + _value;
        }

        public bool IsReady => _timesUP <= Time.time;
    }
}
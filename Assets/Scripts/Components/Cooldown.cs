using System;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class Cooldown
    {
        [SerializeField] public float _value = 1f;

        private float _timesUP;

        public void Reset()
        {
            _timesUP = Time.time + _value;
        }

        public bool IsReady => _timesUP <= Time.time;
    }
}
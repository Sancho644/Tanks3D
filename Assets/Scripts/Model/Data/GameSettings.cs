﻿namespace Scripts.Model.Data
{
    using Scripts.Model.Data.Properties;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Data/GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private FloatPersistentProperty _music = default;
        [SerializeField] private FloatPersistentProperty _sfx = default;

        public FloatPersistentProperty Music => _music;
        public FloatPersistentProperty Sfx => _sfx;

        private static GameSettings _instance = default;
        public static GameSettings I => _instance == null ? LoadGameSetting() : _instance;

        private static GameSettings LoadGameSetting()
        {
            return _instance = Resources.Load<GameSettings>("GameSettings");
        }

        private void OnEnable()
        {
            _music = new FloatPersistentProperty(1, SoundSetting.Music.ToString());
            _sfx = new FloatPersistentProperty(1, SoundSetting.Sfx.ToString());
        }

        private void OnValidate()
        {
            Music.Validate();
            Sfx.Validate();
        }
    }

    public enum SoundSetting
    {
        Music,
        Sfx
    }
}
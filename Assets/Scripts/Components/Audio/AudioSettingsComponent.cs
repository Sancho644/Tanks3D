using System;
using Model.Data;
using Model.Data.Properties;
using UnityEngine;

namespace Components.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSettingsComponent : MonoBehaviour
    {
        [SerializeField] private SoundSetting _mode;

        private FloatPersistentProperty _model;
        private AudioSource _source;

        private void Start()
        {
            _source = GetComponent<AudioSource>();
            _model = FindProperty();

            _model.OnChanged += OnSoundSettingsChanged;

            OnSoundSettingsChanged(_model.Value, _model.Value);
        }

        private void OnSoundSettingsChanged(float newValue, float oldValue)
        {
            _source.volume = newValue;
        }

        private FloatPersistentProperty FindProperty()
        {
            return _mode switch
            {
                SoundSetting.Music => GameSettings.I.Music,
                SoundSetting.Sfx => GameSettings.I.Sfx,
                _ => throw new ArgumentException("Undefined mode")
            };
        }

        private void OnDestroy()
        {
            _model.OnChanged -= OnSoundSettingsChanged;
        }
    }
}
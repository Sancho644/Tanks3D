﻿using UnityEngine;
using System;
using Scripts.Utils;

namespace Scripts.Components.Audio
{
    public class PlaySoundsComponent : MonoBehaviour
    {
        public const string SfxSourceTag = "SfxAudioSource";

        [SerializeField] private AudioData[] _sounds;

        private AudioSource _source;

        public void Play(string id)
        {
            foreach (var audioData in _sounds)
            {
                if (audioData.Id != id) continue;

                if (_source == null)
                    _source = AudioUtils.FindSfxSource();

                _source.PlayOneShot(audioData.Clip);
                break;
            }
        }

        [Serializable]
        public class AudioData
        {
            [SerializeField] private string _id = default;
            [SerializeField] private AudioClip _clip = default;

            public string Id => _id;
            public AudioClip Clip => _clip;
        }
    }
}
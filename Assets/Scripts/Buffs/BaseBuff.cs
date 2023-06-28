using System.Collections;
using Components.Audio;
using Components.ColliderBased;
using Components.GoBased;
using Model;
using Model.Definitions;
using UI;
using UI.Hud;
using UnityEngine;

namespace Buffs
{
    public class BaseBuff : MonoBehaviour
    {
        [SerializeField] private EnterTriggerComponent _trigger;
        [SerializeField] private SpawnComponent _spawnPoints;
        [SerializeField] private GameObject _pointsPrefab;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private int _scoreValue;
        [SerializeField] private float _destroyDelay;

        private PlaySoundsComponent _sounds;
        private GameSession _session;

        private void Start()
        {
            _trigger.OnEnterTriggered += OnTriggered;
            _sounds = GetComponent<PlaySoundsComponent>();
            _session = GameSession.Instance;

            if (_pointsPrefab.TryGetComponent<Points>(out Points points))
            {
                points.SetPoints(_scoreValue);
            }

            _spawnPoints.SetSpawnPrefab(_pointsPrefab);
            StartCoroutine(StartAnimation());
        }

        private IEnumerator StartAnimation()
        {
            var lifeTime = DefsFacade.I.BuffsSettings.DestroyDelay;
            var material = _renderer.material;
            var defaultColor = material.color;

            while (enabled)
            {
                lifeTime -= Time.deltaTime;
                
                if (_destroyDelay > lifeTime)
                {
                    material.color = Color.white;
                    yield return new WaitForSeconds(0.5f);

                    material.color = defaultColor;
                    yield return new WaitForSeconds(0.5f);
                }

                yield return null;
            }
        }

        protected virtual void OnTriggered(GameObject go)
        {
            PlayerScoreController.ModifyScore(_scoreValue);
            _session.Data.PlayerScore.Value = PlayerScoreController.Score;
            _sounds.Play("Up");
            _spawnPoints.SpawnWithoutRotation();

            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _trigger.OnEnterTriggered -= OnTriggered;
        }
    }
}
using System.Collections;
using Components;
using UnityEngine;

namespace Walls
{
    public class IronWallController : MonoBehaviour
    {
        [SerializeField] private GameObject _cube;
        [SerializeField] private Cooldown _cooldown;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private float _destroyDelay;

        private bool _check;
        private readonly Color _defaultColor = Color.white;

        private void Update()
        {
            if (_check)
            {
                Deactivate();
            }
        }

        public void Activate()
        {
            _cube.SetActive(true);
            _cooldown.Reset();
            _check = true;
            _renderer.material.color = _defaultColor;

            StartCoroutine(StartAnimation());
            FlagWallsSpawner.SetActiveObject(false);
        }

        private void Deactivate()
        {
            if (_cooldown.IsReady)
            {
                _cube.SetActive(false);
                _check = false;

                FlagWallsSpawner.SetActiveObject(true);
                StopCoroutine(StartAnimation());
            }
        }

        private IEnumerator StartAnimation()
        {
            var lifeTime = _cooldown.Value;

            while (enabled)
            {
                lifeTime -= Time.deltaTime;
                var material = _renderer.material;

                if (_destroyDelay > lifeTime)
                {
                    material.color = Color.red;
                    yield return new WaitForSeconds(0.5f);

                    material.color = _defaultColor;
                    yield return new WaitForSeconds(0.5f);
                }

                yield return null;
            }
        }
    }
}
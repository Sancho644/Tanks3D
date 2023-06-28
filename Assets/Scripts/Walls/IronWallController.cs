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

            StartCoroutine(StartAnimation());
            TakeColliders();
        }

        private void TakeColliders()
        {
            var list = FlagWalls.Instance;

            foreach (var objects in list.BrickWalls)
            {
                if (objects.TryGetComponent<BoxCollider>(out BoxCollider coll))
                {
                    DeactivateCollider(coll);
                }
            }
        }

        private void DeactivateCollider(BoxCollider coll)
        {
            coll.enabled = !coll.enabled;
        }

        private void Deactivate()
        {
            if (_cooldown.IsReady)
            {
                _cube.SetActive(false);
                TakeColliders();
                _check = false;
            }
        }

        private IEnumerator StartAnimation()
        {
            var lifeTime = _cooldown.Value;
            var material = _renderer.material;
            var defaultColor = material.color;

            while (enabled)
            {
                lifeTime -= Time.deltaTime;

                if (_destroyDelay > lifeTime)
                {
                    material.color = Color.red;
                    yield return new WaitForSeconds(0.5f);

                    material.color = defaultColor;
                    yield return new WaitForSeconds(0.5f);
                }

                yield return null;
            }
        }
    }
}
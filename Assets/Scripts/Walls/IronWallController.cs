using Components;
using Scripts.Components;
using UnityEngine;

namespace Walls
{
    public class IronWallController : MonoBehaviour
    {
        [SerializeField] private GameObject _cube;
        [SerializeField] private Cooldown _cooldown; 

        private bool _check = false;

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

            TakeColliders();
        }

        private void TakeColliders()
        {
            var list = FlagWalls.Instance;

            foreach (var objects in list.BrickWalls)
            {
                if (objects.TryGetComponent<BoxCollider>(out BoxCollider collider))
                {
                    DeactivateCollider(collider);
                }
            }
        }

        private void DeactivateCollider(BoxCollider collider)
        {
            collider.enabled = !collider.enabled;
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
    }
}
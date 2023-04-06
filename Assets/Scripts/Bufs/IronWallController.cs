namespace Scripts.Bufs
{
    using Scripts.Components;
    using UnityEngine;

    public class IronWallController : MonoBehaviour
    {
        [SerializeField] private Cooldown _cooldown = default;

        private bool _check = false;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_check)
            {
                Deactivate();
            }
        }

        public void Activate()
        {
            gameObject.SetActive(true);
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
            if (collider.enabled)
            {
                collider.enabled = false;
            }
            else
            {
                collider.enabled = true;
            }
        }

        private void Deactivate()
        {
            if (_cooldown.IsReady)
            {
                gameObject.SetActive(false);
                TakeColliders();
                _check = false;
            }
        }
    }
}
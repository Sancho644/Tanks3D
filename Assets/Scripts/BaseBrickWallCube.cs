namespace Scripts
{
    using Scripts.Components.ColliderBased;
    using Scripts.Components;
    using UnityEngine;
    using Scripts.Components.GoBased;

    public class BaseBrickWallCube : MonoBehaviour
    {
        [SerializeField] private EnterCollisionComponent _collision = default;
        [SerializeField] private WallColliderReducer _reducer = default;
        [SerializeField] private GameObject _wall = default;

        [SerializeField] protected PlaySoundsComponent _play = default;
        [SerializeField] protected SpawnComponent _spawn = default;

        private void Start()
        {
            _collision.OnAction += OnCollisionAction;
        }

        public virtual void OnCollisionAction(string tag, GameObject go)
        {
            if (tag == "Bullet")
            {
                Destroy(_wall);
                _play.Play("Die");
                _spawn.Spawn();
                _reducer.Reduce();
            }
        }

        private void OnDestroy()
        {
            _collision.OnAction -= OnCollisionAction;
        }
    }
}
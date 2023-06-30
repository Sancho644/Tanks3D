using Components.Audio;
using Components.ColliderBased;
using Components.GoBased;
using UnityEngine;

namespace Walls
{
    public class BaseBrickWallCube : MonoBehaviour
    {
        [SerializeField] private EnterCollisionComponent _collision;
        [SerializeField] private WallColliderReducer _reducer;
        [SerializeField] private GameObject _wall;

        [SerializeField] protected PlaySoundsComponent _play;
        [SerializeField] protected SpawnComponent _spawn;

        private void Start()
        {
            _collision.OnAction += OnCollisionAction;
        }

        protected virtual void OnCollisionAction(string tag, GameObject go)
        {
            if (tag == "Bullet")
            {
                Action();
            }
        }

        protected virtual void Action()
        {
            Destroy(_wall);

            _play.Play("Die");
            _spawn.Spawn();
            _reducer.Reduce();
        }

        private void OnDestroy()
        {
            _collision.OnAction -= OnCollisionAction;
        }
    }
}
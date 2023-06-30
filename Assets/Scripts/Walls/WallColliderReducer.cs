using System.Collections;
using UnityEngine;

namespace Walls
{
    public class WallColliderReducer : MonoBehaviour
    {
        [SerializeField] private float _time = 1f;
        [SerializeField] private float _size = 2f;
        [SerializeField] private float _deltaSize = 0.006f;
        [SerializeField] private BoxCollider _box;

        public void Reduce()
        {
            StartCoroutine(ReduceCollision());
        }

        private IEnumerator ReduceCollision()
        {
            var time = 0f;

            while (time < _time)
            {
                if (_size <= 0) break;

                time += Time.deltaTime;
                _box.size = new Vector3(_size, _size, _size);
                _size -= _deltaSize;

                yield return null;
            }

            Destroy(gameObject);
        }
    }
}
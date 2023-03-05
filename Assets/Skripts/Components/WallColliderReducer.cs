using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Skripts.Components
{
    public class WallColliderReducer : MonoBehaviour
    {
        [SerializeField] private float _time;
        [SerializeField] private float _size;
        [SerializeField] private BoxCollider _box;
        [SerializeField] private UnityEvent _onComplete;

        public void GetReduce()
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
                _size -= 0.01f;

                yield return null;
            }

            _onComplete?.Invoke();
        }
    }
}
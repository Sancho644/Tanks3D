namespace Scripts.Components
{
    using System.Collections;
    using UnityEngine;

    public class WallColliderReducer : MonoBehaviour
    {
        [SerializeField] private float _time = 1f;
        [SerializeField] private float _size = 2f;
        [SerializeField] private BoxCollider _box = default;

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
                _size -= 0.01f;

                yield return null;
            }

            Destroy(gameObject);
        }
    }
}
using UnityEngine;

namespace Scripts
{
    public class DestractibleCube : MonoBehaviour
    {
        [SerializeField] private GameObject _object;
        [SerializeField] private float _cubeSize = 0.2f;
        [SerializeField] private int _cubesInRow = 5;

        [SerializeField] private float _explosionForce = 50f;
        [SerializeField] private float _explosionRadius = 4f;
        [SerializeField] private float _explosionUpward = 0.4f;

        private float _cubesPivotDistance;
        private Vector3 _cubesPivot;

        private void Start()
        {
            _cubesPivotDistance = _cubeSize * _cubesInRow / 2;
            _cubesPivot = new Vector3(_cubesPivotDistance, _cubesPivotDistance, _cubesPivotDistance);
        }

        public void Explode()
        {
            for (int x = 0; x < _cubesInRow; x++)
            {
                for (int y = 0; y < _cubesInRow; y++)
                {
                    for (int z = 0; z < _cubesInRow; z++)
                    {
                        CreatePiece(x, y, z);
                    }
                }
            }

            AddForce();
        }

        private void AddForce()
        {
            var explosionPos = transform.position;

            Collider[] colliders = Physics.OverlapSphere(explosionPos, _explosionRadius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius, _explosionUpward);
                }
            }
        }

        private void CreatePiece(int x, int y, int z)
        {
            var position = _object.transform.position = transform.position + new Vector3(_cubeSize * x, _cubeSize * y, _cubeSize * z) - _cubesPivot;
            _object.transform.localScale = new Vector3(_cubeSize, _cubeSize, _cubeSize);

            Instantiate(_object, position, Quaternion.identity);
        }
    }
}
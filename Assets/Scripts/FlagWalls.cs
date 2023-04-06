namespace Scripts
{
    using UnityEngine;

    public class FlagWalls : MonoBehaviour
    {
        [SerializeField] private GameObject[] _brickWalls = default;
        [SerializeField] private GameObject[] _ironWalls = default;

        public GameObject[] BrickWalls => _brickWalls;
        public GameObject[] IronWalls => _ironWalls;

        public static FlagWalls Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
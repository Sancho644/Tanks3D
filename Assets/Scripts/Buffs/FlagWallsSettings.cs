using UnityEngine;

namespace Buffs
{
    [CreateAssetMenu(menuName = "Data/FlagWallsSettings", fileName = "FlagWallsSettings")]
    public class FlagWallsSettings : ScriptableObject
    {
        [SerializeField] private GameObject[] _brickWalls;
        [SerializeField] private GameObject[] _ironWalls;

        public GameObject[] BrickWalls => _brickWalls;
        public GameObject[] IronWalls => _ironWalls;
    }
}
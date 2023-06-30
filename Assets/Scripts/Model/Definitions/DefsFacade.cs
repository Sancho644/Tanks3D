using Buffs;
using Model.Definitions.LevelsDefs;
using UnityEngine;

namespace Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/DefsFacade", fileName = "DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        [SerializeField] private LevelSettings _buffsSettings;
        [SerializeField] private FlagWallsSettings _flagWalls;

        public LevelSettings BuffsSettings => _buffsSettings;
        public FlagWallsSettings FlagWalls => _flagWalls;

        private static DefsFacade _instance;
        public static DefsFacade I => _instance == null ? LoadDefs() : _instance;

        private static DefsFacade LoadDefs()
        {
            return _instance = Resources.Load<DefsFacade>("DefsFacade");
        }
    }
}
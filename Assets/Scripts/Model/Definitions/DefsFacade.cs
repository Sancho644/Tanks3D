using UnityEngine;

//NOTE: скорее всего удалить
namespace Scripts.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/DefsFacade", fileName = "DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        /*[SerializeField] private LevelOneSettings _levelOne;

        public LevelOneSettings LevelOne => _levelOne;

        private static DefsFacade _instance;
        public static DefsFacade I => _instance == null ? LoadDefs() : _instance;

        private static DefsFacade LoadDefs()
        {
            return _instance = Resources.Load<DefsFacade>("DefsFacade");
        }*/
    }
}
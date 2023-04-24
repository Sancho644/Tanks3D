﻿using Scripts.Model.Definitions.LevelsDefs.TanksSpawnDefs;
using UnityEngine;

//NOTE: скорее всего удалить
namespace Scripts.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/DefsFacade", fileName = "DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        [SerializeField] private LevelOneDef _levelOne;

        public LevelOneDef LevelOne => _levelOne;

        private static DefsFacade _instance;
        public static DefsFacade I => _instance == null ? LoadDefs() : _instance;

        private static DefsFacade LoadDefs()
        {
            return _instance = Resources.Load<DefsFacade>("DefsFacade");
        }
    }
}
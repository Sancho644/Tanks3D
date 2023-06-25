using System;
using Model.Data.Properties;
using UnityEngine;

namespace Model.Data
{
    [Serializable]
    public class PlayerData
    {
        public IntProperty Health = new IntProperty();
        public IntProperty Armor = new IntProperty();
        public IntProperty PlayerScore = new IntProperty();
        public StringProperty CurrentLevel = new StringProperty();

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
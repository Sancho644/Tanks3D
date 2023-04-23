using Scripts.Model.Data.Properties;
using System;
using UnityEngine;

namespace Scripts.Components.Model
{
    [Serializable]
    public class PlayerData
    {
        public IntProperty Health = new IntProperty();
        public IntProperty Armor = new IntProperty();

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
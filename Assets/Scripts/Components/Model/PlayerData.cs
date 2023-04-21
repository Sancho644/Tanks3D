namespace Scripts.Components.Model
{
    using Scripts.Model.Data.Properties;
    using System;
    using UnityEngine;

    [Serializable]
    public class PlayerData
    {
        public IntProperty Health = new IntProperty();
        public IntProperty Armor = new IntProperty();

        //public int Health = 3;
        //public int Armor = 0;

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
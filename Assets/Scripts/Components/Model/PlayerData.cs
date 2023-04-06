namespace Scripts.Components.Model
{
    using System;
    using UnityEngine;

    [Serializable]
    public class PlayerData
    {
        public int Hp = 3;
        public int Armor = 0;

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
        }
    }
}
﻿using Scripts.Creatures.Player;
using UnityEngine;

namespace Scripts.Buffs
{
    public class DamageBuff : BaseBuff
    {
        protected override void OnTriggered(GameObject go)
        {
            if (go.TryGetComponent<Player>(out Player player))
            {
                player.EnableDamageBuff();
            }

            base.OnTriggered(gameObject);
        }
    }
}
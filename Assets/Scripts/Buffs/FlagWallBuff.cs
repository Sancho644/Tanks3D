﻿using Scripts.Walls;
using UnityEngine;

namespace Scripts.Buffs
{
    public class FlagWallBuff : BaseBuff
    {
        protected override void OnTriggered(GameObject go)
        {
            var list = FlagWalls.Instance;

            foreach (var objects in list.BrickWalls)
            {
                objects.SetActive(true);
            }

            base.OnTriggered(gameObject);
        }
    }
}
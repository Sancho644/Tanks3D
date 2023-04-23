﻿using Scripts.Walls;
using UnityEngine;

namespace Scripts.Buffs
{
    public class IronFlagWallBuff : BaseBuff
    {
        protected override void OnTriggered(GameObject go)
        {
            var ironWallsList = FlagWalls.Instance;

            foreach (var objects in ironWallsList.IronWalls)
            {
                if (objects.TryGetComponent<IronWallController>(out IronWallController active))
                {
                    active.Activate();
                }
            }

            base.OnTriggered(go);
        }
    }
}
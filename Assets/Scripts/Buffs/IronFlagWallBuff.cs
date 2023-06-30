using UnityEngine;
using Walls;

namespace Buffs
{
    public class IronFlagWallBuff : BaseBuff
    {
        protected override void OnTriggered(GameObject go)
        {
            var ironWallsList = FlagWallsSpawner.IronWallsList;

            foreach (var objects in ironWallsList)
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
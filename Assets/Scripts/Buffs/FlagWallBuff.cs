using UnityEngine;
using Walls;

namespace Buffs
{
    public class FlagWallBuff : BaseBuff
    {
        protected override void OnTriggered(GameObject go)
        {
            var brickWalls = FlagWallsSpawner.BrickWallsList;

            foreach (var objects in brickWalls)
            {
                objects.SetActive(true);
            }

            base.OnTriggered(gameObject);
        }
    }
}
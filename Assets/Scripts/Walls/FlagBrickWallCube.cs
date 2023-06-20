using UnityEngine;

namespace Walls
{
    public class FlagBrickWallCube : BaseBrickWallCube
    {
        protected override void OnCollisionAction(string tag, GameObject go)
        {
            base.OnCollisionAction(tag, go);
        }

        protected override void Action()
        {
            _play.Play("Die");
            _spawn.Spawn();
            gameObject.SetActive(false);
        }
    }
}
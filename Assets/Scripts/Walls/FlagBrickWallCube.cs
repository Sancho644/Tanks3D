using UnityEngine;

namespace Scripts.Walls
{
    public class FlagBrickWallCube : BaseBrickWallCube
    {
        public override void OnCollisionAction(string tag, GameObject go)
        {
            base.OnCollisionAction(tag, go);
        }

        public override void Action()
        {
            _play.Play("Die");
            _spawn.Spawn();
            gameObject.SetActive(false);
        }
    }
}
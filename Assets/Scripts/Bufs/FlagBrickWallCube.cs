namespace Scripts.Bufs
{
    using UnityEngine;

    public class FlagBrickWallCube : BaseBrickWallCube
    {
        public override void OnCollisionAction(string tag, GameObject go)
        {
            if (tag == "Bullet")
            {
                _play.Play("Die");
                _spawn.Spawn();
                gameObject.SetActive(false);
            }
        }
    }
}
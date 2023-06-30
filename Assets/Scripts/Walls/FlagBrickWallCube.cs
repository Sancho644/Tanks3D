namespace Walls
{
    public class FlagBrickWallCube : BaseBrickWallCube
    {
        protected override void Action()
        {
            _play.Play("Die");
            _spawn.Spawn();
            gameObject.SetActive(false);
        }
    }
}
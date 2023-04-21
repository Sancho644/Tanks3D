namespace Scripts.Bufs
{
    using Scripts.Creatures.Player;
    using UnityEngine;

    public class DamageBuff : BaseFlagWallBuff
    {
        protected override void OnTriggered(GameObject go)
        {
            if (go.TryGetComponent<Player>(out Player player))
            {
                player.EnableDamageBuff();
                Destroy(gameObject);
            }
        }
    }
}
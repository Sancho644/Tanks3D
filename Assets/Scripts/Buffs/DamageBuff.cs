using Creatures.Player;
using UnityEngine;

namespace Buffs
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
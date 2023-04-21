namespace Scripts.Bufs
{
    using UnityEngine;

    public class IronFlagWallBuff : BaseFlagWallBuff
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

            Destroy(gameObject);
        }
    }
}
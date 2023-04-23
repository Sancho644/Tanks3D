using Scripts.Components.LevelManagement;

namespace Scripts.Model.Data
{
    public static class CountOfEnemies
    {
        private static int _count = 0;

        public static void ModifyCount(int value)
        {
            _count += value;

            if (_count == 0)
            {
                var exitLevel = ExitLevelComponent.Instance;
                exitLevel.Exit();
            }
        }
    }
}
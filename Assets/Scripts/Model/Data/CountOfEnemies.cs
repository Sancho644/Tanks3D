using Scripts.Components.LevelManagement;
using System;

namespace Scripts.Model.Data
{
    public static class CountOfEnemies
    {
        private static int _count = 0;

        public static int Count => _count;

        public static event Action OnModify;

        public static void ModifyCount(int value)
        {
            if (value < 0)
            {
                OnModify?.Invoke();
            }

            _count += value;

            if (_count == 0)
            {
                var exitLevel = ExitLevelComponent.Instance;
                exitLevel.Exit();
            }
        }

        public static void SetCount(int value)
        {
            _count = value;
        }
    }
}
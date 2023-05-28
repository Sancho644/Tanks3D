using Scripts.Components.LevelManagement;
using System;

namespace Scripts.Model.Data
{
    public static class CountOfEnemies
    {
        private static int _totalEnemies = 0;
        public static int Count { get; private set; } = 0;

        public static int TotalEnemies => _totalEnemies;

        public static event Action OnModify;

        public static void ModifyCount(int value)
        {
            if (value < 0)
            {
                _totalEnemies += value;
                OnModify?.Invoke();
            }

            Count += value;

            if (Count == 0)
            {
                var exitLevel = ExitLevelComponent.Instance;
                exitLevel.Exit();
            }
        }

        public static void SetTotalEnemies(int value)
        {
            _totalEnemies = value;            
        }

        public static void SetCount(int value)
        {
            Count = value;
        }
    }
}
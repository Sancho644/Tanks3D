using System;
using Components.LevelManagement;

namespace Model.Data
{
    public static class CountOfEnemies
    {
        public static int Count { get; private set; }
        public static int TotalEnemies { get; private set; }

        public static event Action OnModify;

        public static void ModifyCount(int value)
        {
            if (value < 0)
            {
                TotalEnemies += value;
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
            TotalEnemies = value;            
        }

        public static void SetCount(int value)
        {
            Count = value;
        }
    }
}
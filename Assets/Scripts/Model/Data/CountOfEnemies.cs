using System;

namespace Model.Data
{
    public static class CountOfEnemies
    {
        public static int Count { get; private set; }
        public static int TotalEnemies { get; private set; }
        public static event Action OnModify;
        public static event Action OnEnemyEnds;

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
                OnEnemyEnds?.Invoke();
            }
        }

        public static void SetTotalEnemies(int value)
        {
            TotalEnemies = value;
            OnModify?.Invoke();
        }

        public static void SetCount(int value)
        {
            Count = value;
        }
    }
}
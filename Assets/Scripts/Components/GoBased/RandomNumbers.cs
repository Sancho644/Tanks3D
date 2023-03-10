using UnityEngine;

namespace Scripts.Components.GoBased
{
    public static class RandomNumbers
    {
        public static int RandomWithTwoNumber(int first, int second)
        {
            int[] _numbers = new int[2] { first, second };
            float rand = Random.Range(0f, 100f);

            if (rand < 50)
            {
                return _numbers[0];
            }
            else
            {
                return _numbers[1];
            }
        }
    }
}
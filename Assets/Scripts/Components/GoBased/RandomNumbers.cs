namespace Scripts.Components.GoBased
{
    using UnityEngine;

    public static class RandomNumbers
    {
        public static int RandomWithTwoNumber(int first, int second)
        {
            int[] numbers = new int[2] { first, second };
            float rand = Random.Range(0f, 100f);

            return rand < 50 ? numbers[0] : numbers[1];
        }
    }
}
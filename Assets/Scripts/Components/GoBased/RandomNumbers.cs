using UnityEngine;

namespace Scripts.Components.GoBased
{
    public static class RandomNumbers
    {
        public static float RandomWithTwoNumber(float first, float second)
        {
            float[] numbers = new float[2] { first, second };
            float rand = Random.Range(0f, 100f);

            return rand < 50 ? numbers[0] : numbers[1];
        }
    }
}
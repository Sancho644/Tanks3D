using UnityEngine;

namespace Components.GoBased
{
    public static class RandomNumbers
    {
        public static float RandomWithTwoNumber(float first, float second)
        {
            var numbers = new float[2] { first, second };
            var rand = Random.Range(0f, 100f);

            return rand < 50 ? numbers[0] : numbers[1];
        }
    }
}
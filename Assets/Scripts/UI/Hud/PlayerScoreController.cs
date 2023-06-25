namespace UI.Hud
{
    public static class PlayerScoreController
    {
        public static int Score { get; private set; }

        public static void SetScore(int value)
        {
            Score = value;
        }

        public static void ModifyScore(int value)
        {
            Score += value;
        }
    }
}
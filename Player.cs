namespace AZ_Kviz
{
    internal static partial class Player
    {
        public enum Players
        {
            PlayerOne,
            PlayerTwo
        }
        public static Players currentPlayer { get; private set; } = Players.PlayerOne;

        public static void NextPlayer()
        {
            currentPlayer = (currentPlayer == Players.PlayerOne) ? Players.PlayerTwo : Players.PlayerOne;
        }
    }

    internal static partial class PlayerExtensions
    {
        public static string GetText(this Player.Players s)
        {
            return s switch
            {
                Player.Players.PlayerOne => "Hráč 1",
                Player.Players.PlayerTwo => "Hráč 2",
                _ => ""
            };
        }
    }
}

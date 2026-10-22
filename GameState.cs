using System;
using System.Drawing;

namespace AZ_Kviz
{
    internal sealed class GameState
    {
        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }
        public Player CurrentPlayer { get; private set; }
        public Player OtherPlayer => CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;

        public event Action? PlayerChanged;
        public event Action? StatsChanged;

        public GameState(string playerOneName, Color playerOneColor, string playerTwoName, Color playerTwoColor)
        {
            PlayerOne = new Player(playerOneName, playerOneColor);
            PlayerTwo = new Player(playerTwoName, playerTwoColor);
            CurrentPlayer = PlayerOne;
        }

        public void NextPlayer()
        {
            CurrentPlayer = CurrentPlayer == PlayerOne ? PlayerTwo : PlayerOne;
            PlayerChanged?.Invoke();
        }

        public TileManager.TileStates ApplyAnswer(Answers answer)
        {
            Player otherPlayer = OtherPlayer;
            TileManager.TileStates tileState;

            switch (answer)
            {
                case Answers.Correct:
                    CurrentPlayer.Correct++;
                    tileState = CurrentPlayer == PlayerOne
                        ? TileManager.TileStates.FirstPlayer_Used
                        : TileManager.TileStates.SecondPlayer_Used;
                    break;

                case Answers.Incorrect:
                    CurrentPlayer.Incorrect++;
                    tileState = TileManager.TileStates.Incorrect;
                    break;

                case Answers.SecondCorrect:
                    CurrentPlayer.Incorrect++;
                    otherPlayer.Correct++;
                    tileState = otherPlayer == PlayerOne
                        ? TileManager.TileStates.FirstPlayer_Used
                        : TileManager.TileStates.SecondPlayer_Used;
                    break;

                case Answers.SecondIncorrect:
                    CurrentPlayer.Incorrect++;
                    otherPlayer.Incorrect++;
                    tileState = TileManager.TileStates.Blocked;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(answer), answer, "Neznámý výsledek odpovìdi.");
            }

            StatsChanged?.Invoke();
            return tileState;
        }

        public void ResetScore()
        {
            PlayerOne.Reset();
            PlayerTwo.Reset();
            CurrentPlayer = PlayerOne;

            PlayerChanged?.Invoke();
            StatsChanged?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const string Player1 = "player1";
        private const string Player2 = "player2";

        private readonly Dictionary<string, int> _scores = new Dictionary<string, int>()
        {
            {Player1, 0},
            {Player2, 0}
        };

        public void WonPoint(string playerName) => _scores[playerName] += 1;

        public string GetScore()
        {
            if (IsDraw())
            {
                return GetScoreForDraw();
            }

            return IsGreaterThen4Score()
                ? GetScoreForGreaterThen4Score()
                : GetScoreForLessThen4Score();
        }

        private bool IsGreaterThen4Score() => _scores[Player1] >= 4 || _scores[Player2] >= 4;

        private bool IsDraw() => _scores[Player1] == _scores[Player2];

        private string GetScoreForLessThen4Score() =>
            $"{GetScoreText(_scores[Player1])}-{GetScoreText(_scores[Player2])}";

        private static string GetScoreText(int tempScore)
        {
            switch (tempScore)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    return "";
            }
        }

        private string GetScoreForGreaterThen4Score()
        {
            var scoresDifference = _scores[Player1] - _scores[Player2];
            var winner = scoresDifference > 0
                ? Player1
                : Player2;

            return Math.Abs(scoresDifference) == 1
                ? $"Advantage {winner}"
                : $"Win for {winner}";
        }

        private string GetScoreForDraw()
        {
            switch (_scores[Player1])
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }
    }
}
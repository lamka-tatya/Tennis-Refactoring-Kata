namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int _player1Score;
        private int _player2Score;

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                _player1Score += 1;
            }
            else
            {
                _player2Score += 1;
            }
        }

        public string GetScore()
        {
            if (_player1Score == _player2Score)
            {
                return GetScoreForDraw();
            }

            if (_player1Score >= 4 || _player2Score >= 4)
            {
                return GetScoreForGreaterThen4Score();
            }

            return GetScoreForLessThen4Score();
        }

        private string GetScoreForLessThen4Score() => $"{GetScoreText(_player1Score)}-{GetScoreText(_player2Score)}";

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
            string score;
            var minusResult = _player1Score - _player2Score;
            if (minusResult == 1)
            {
                score = "Advantage player1";
            }
            else if (minusResult == -1)
            {
                score = "Advantage player2";
            }
            else if (minusResult >= 2)
            {
                score = "Win for player1";
            }
            else
            {
                score = "Win for player2";
            }

            return score;
        }

        private string GetScoreForDraw()
        {
            switch (_player1Score)
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
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

        private string GetScoreForLessThen4Score()
        {
            var score = "";
            
            for (var i = 1; i < 3; i++)
            {
                int tempScore;
                
                if (i == 1)
                {
                    tempScore = _player1Score;
                }
                else
                {
                    score += "-";
                    tempScore = _player2Score;
                }

                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
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
            string score;
            switch (_player1Score)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }
    }
}
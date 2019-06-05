namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;

        private string _p1Res = "";
        private string _p2Res = "";

        public TennisGame2()
        {
            _p1Point = 0;
        }

        public string GetScore()
        {
            var score = "";
            if (_p1Point == _p2Point && _p1Point < 3)
            {
                switch (_p1Point)
                {
                    case 0:
                        score = "Love";
                        break;
                    case 1:
                        score = "Fifteen";
                        break;
                    case 2:
                        score = "Thirty";
                        break;
                }

                score += "-All";
            }
            if (_p1Point == _p2Point && _p1Point > 2)
            {
                score = "Deuce";
            }

            if (_p1Point > 0 && _p2Point == 0)
            {
                switch (_p1Point)
                {
                    case 1:
                        _p1Res = "Fifteen";
                        break;
                    case 2:
                        _p1Res = "Thirty";
                        break;
                    case 3:
                        _p1Res = "Forty";
                        break;
                }

                _p2Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }
            if (_p2Point > 0 && _p1Point == 0)
            {
                switch (_p2Point)
                {
                    case 1:
                        _p2Res = "Fifteen";
                        break;
                    case 2:
                        _p2Res = "Thirty";
                        break;
                    case 3:
                        _p2Res = "Forty";
                        break;
                }

                _p1Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point > _p2Point && _p1Point < 4)
            {
                switch (_p1Point)
                {
                    case 2:
                        _p1Res = "Thirty";
                        break;
                    case 3:
                        _p1Res = "Forty";
                        break;
                }

                switch (_p2Point)
                {
                    case 1:
                        _p2Res = "Fifteen";
                        break;
                    case 2:
                        _p2Res = "Thirty";
                        break;
                }

                score = _p1Res + "-" + _p2Res;
            }
            if (_p2Point > _p1Point && _p2Point < 4)
            {
                switch (_p2Point)
                {
                    case 2:
                        _p2Res = "Thirty";
                        break;
                    case 3:
                        _p2Res = "Forty";
                        break;
                }

                switch (_p1Point)
                {
                    case 1:
                        _p1Res = "Fifteen";
                        break;
                    case 2:
                        _p1Res = "Thirty";
                        break;
                }

                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point > _p2Point && _p2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (_p2Point > _p1Point && _p1Point >= 3)
            {
                score = "Advantage player2";
            }

            if (_p1Point >= 4 && _p2Point >= 0 && _p1Point - _p2Point >= 2)
            {
                score = "Win for player1";
            }
            if (_p2Point >= 4 && _p1Point >= 0 && _p2Point - _p1Point >= 2)
            {
                score = "Win for player2";
            }
            
            return score;
        }

        private void P1Score()
        {
            _p1Point++;
        }

        private void P2Score()
        {
            _p2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
            {
                P1Score();
            }
            else
            {
                P2Score();
            }
        }
    }
}


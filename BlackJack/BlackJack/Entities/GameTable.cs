using System.Collections.Generic;
using BlackJack.Enums;

namespace BlackJack.Entities
{
    public class GameTable 
    {
        private readonly Dealer _Dealer;
        private readonly Player _Player;
        private readonly Settlement _Settlement;
        public GameStatus GameStatus { get; protected set; }
        public Turn Turn { get; private set; }

        public GameTable(Dealer dealer, Player player, Settlement settlement)
        {
            _Dealer = dealer;
            _Player = player;
            _Settlement = settlement;
            GameStatus = GameStatus.End;
        }

        public Dealer Dealer { get { return _Dealer; } }
        public Player Player { get { return _Player; }}
        public List<Card> DealerHand { get { return _Dealer.Hand; }}
        public List<Card> PlayerHand { get { return _Player.Hand; } }
        public int PlayerHandScore { get { return _Player.HighestHandScore; } }
        public int DealerHandScore { get { return _Dealer.HighestHandScore; } }
        public int PlayerPoint { get { return _Player.Point; }}
        public int DealerPoint { get { return _Dealer.Point; }}

        public void GameStart()
        {
            _Player.Reset();
            _Dealer.Reset();
            _Dealer.Shuffle();
            Continue();
        }

        private void Continue()
        {
            var dealCard = _Dealer.DealCard();
            dealCard.SetHidden();
            _Dealer.Hit(dealCard);
            _Dealer.Hit(_Dealer.DealCard());
            _Player.Hit(_Dealer.DealCard());
            _Player.Hit(_Dealer.DealCard());
            Turn = Turn.Player;
            GameStatus = GameStatus.PlayerInProcess;
        }

        public void Hit()
        {
            if (GameStatus == GameStatus.End)
            {
                Continue();
                return;
            }
            if (Turn == Turn.Player)
            {
                _Player.Hit(_Dealer.DealCard());
                if (!_Player.IsExplode) return;
                GameStatus = GameStatus.End;
                _Settlement(_Dealer,_Player);
            }
            else
            {
                while (_Dealer.HighestHandScore<=16)
                {
                    _Dealer.Hit(_Dealer.DealCard());
                }
                GameStatus = GameStatus.End;
                _Settlement(_Dealer, _Player);
            }
        }


        public void Stay()
        {
            SwitchTurn();
        }

        private void SwitchTurn()
        {
            Turn = Turn == Turn.Player ? Turn.Dealer : Turn.Player;
        }

        public delegate void Settlement(Dealer dealer, Player player);

    }
}
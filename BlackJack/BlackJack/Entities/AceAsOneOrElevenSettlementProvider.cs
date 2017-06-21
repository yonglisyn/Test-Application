using System;
using BlackJack.Enums;

namespace BlackJack.Entities
{
    public class AceAsOneOrElevenSettlementProvider
    {
        public void Settlement(Dealer dealer, Player player)
        {
            var resultType = CalculateResult(dealer, player);
            switch (resultType)
            {
                case ResultType.BlackJack:
                    player.AddPoint(15);
                    dealer.AddPoint(-15);
                    break;
                case ResultType.Win:
                    player.AddPoint(10);
                    dealer.AddPoint(-10);
                    break;
                case ResultType.Lost:
                    player.AddPoint(-10);
                    dealer.AddPoint(10);
                    break;
                case ResultType.Push:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            dealer.Clear();
            player.Clear();
        }

        private ResultType CalculateResult(Dealer dealer, Player player)
        {
            if (player.HighestHandScore == dealer.HighestHandScore)
                return ResultType.Push;
            if (player.IsBlackJack)
                return ResultType.BlackJack;
            if(player.IsExplode)
                return ResultType.Lost;
            if(dealer.IsExplode)
                return ResultType.Win;
            if (player.HighestHandScore > dealer.HighestHandScore)
                return ResultType.Win;
            if (player.HighestHandScore < dealer.HighestHandScore)
                return ResultType.Lost;
            return ResultType.Push;
        }
    }
}
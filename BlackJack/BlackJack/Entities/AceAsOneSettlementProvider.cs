using System;
using BlackJack.Enums;

namespace BlackJack.Entities
{
    public class AceAsOneSettlementProvider
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
        }

        private ResultType CalculateResult(Dealer dealer, Player player)
        {
            if (player.HandScore == dealer.HandScore)
                return ResultType.Push;
            if (player.IsBlackJack)
                return ResultType.BlackJack;
            if (player.HandScore > dealer.HandScore || dealer.IsExplode)
                return ResultType.Win;
            if (player.HandScore < dealer.HandScore || player.IsExplode)
                return ResultType.Lost;
            return ResultType.Push;
        }
    }

}

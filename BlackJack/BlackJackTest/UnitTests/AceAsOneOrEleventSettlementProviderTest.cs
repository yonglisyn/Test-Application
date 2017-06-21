using System.Collections.Generic;
using BlackJack.Entities;
using NUnit.Framework;

namespace BlackJackTest.UnitTests
{
    [TestFixture]
    public class AceAsOneOrEleventSettlementProviderTest
    {
        [Test]
        public void Player_BlackJack_Win_15_Points()
        {
            //Arrange
            var player = new Player(0);
            player.Hit(new Card("A"));
            player.Hit(new Card("J"));
            var dealer = new Dealer(new List<Deck> { new Deck() }, 0);
            var settlementProvider = new AceAsOneOrElevenSettlementProvider();
            //Act
            settlementProvider.Settlement(dealer,player);

            //Assert
            Assert.AreEqual(15,player.Point);
            Assert.AreEqual(-15,dealer.Point);
        }
    }
}

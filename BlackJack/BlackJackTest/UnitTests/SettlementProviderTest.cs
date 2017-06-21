using System.Collections.Generic;
using BlackJack.Entities;
using NUnit.Framework;

namespace BlackJackTest.UnitTests
{
    [TestFixture]
    public class SettlementProviderTest
    {
        [Test]
        public void Player_BlackJack_Win_15_Points()
        {
            //Arrange
            var player = new Player(0);
            player.Hit(new Card("11"));
            player.Hit(new Card("J"));
            var dealer = new Dealer(new List<Deck> { new Deck() }, 0);
            var settlementProvider = new AceAsOneSettlementProvider();
            //Act
            settlementProvider.Settlement(dealer,player);

            //Assert
            Assert.AreEqual(15,player.Point);
            Assert.AreEqual(-15,dealer.Point);
        }

        [Test]
        public void Player_Win_Win_10_Points()
        {
            //Arrange
            var player = new Player(0);
            player.Hit(new Card("2"));
            player.Hit(new Card("3"));
            var dealer = new Dealer(new List<Deck> { new Deck() }, 0);
            dealer.Hit(new Card("2"));
            dealer.Hit(new Card("2"));
            var settlementProvider = new AceAsOneSettlementProvider();
            //Act
            settlementProvider.Settlement(dealer,player);

            //Assert
            Assert.AreEqual(10,player.Point);
            Assert.AreEqual(-10,dealer.Point);
        }

        [Test]
        public void Player_Lost_Lose_10_Points()
        {
            //Arrange
            var player = new Player(0);
            player.Hit(new Card("2"));
            player.Hit(new Card("2"));
            var dealer = new Dealer(new List<Deck> { new Deck() }, 0);
            dealer.Hit(new Card("2"));
            dealer.Hit(new Card("3"));
            var settlementProvider = new AceAsOneSettlementProvider();
            //Act
            settlementProvider.Settlement(dealer,player);

            //Assert
            Assert.AreEqual(-10,player.Point);
            Assert.AreEqual(10,dealer.Point);
        }

        [Test]
        public void Push_No_Point_Change()
        {
            //Arrange
            var player = new Player(0);
            player.Hit(new Card("2"));
            player.Hit(new Card("2"));
            var dealer = new Dealer(new List<Deck> { new Deck() }, 0);
            dealer.Hit(new Card("2"));
            dealer.Hit(new Card("2"));
            var settlementProvider = new AceAsOneSettlementProvider();
            //Act
            settlementProvider.Settlement(dealer,player);

            //Assert
            Assert.AreEqual(0,player.Point);
            Assert.AreEqual(0,dealer.Point);
        }
    }
}

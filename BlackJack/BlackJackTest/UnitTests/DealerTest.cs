using System.Collections.Generic;
using BlackJack.Entities;
using NUnit.Framework;

namespace BlackJackTest.UnitTests
{
    [TestFixture]
    public class DealerTest
    {
        [Test]
        public void Dealer_Should_Deal_Card_One_By_One()
        {
            //Arrange
            List<Deck> decks = new List<Deck>{new Deck()};
            var dealer = new Dealer(decks,0);

            //Act
            var result = dealer.DealCard();

            //Assert
            Assert.AreEqual("A",result.Rank);
        }

        [Test]
        public void Dealer_Should_Able_To_Check_Remaining_Cards()
        {
            //Arrange
            List<Deck> decks = new List<Deck>{new Deck()};
            var dealer = new Dealer(decks,0);

            //Act
            dealer.DealCard();

            //Assert
            Assert.AreEqual(51,dealer.RemainingCardsCount);
        }

        [Test]
        public void Dealer_Should_Have_Dealer_Hand()
        {
            //Arrange
            Dealer dealer = new Dealer(new List<Deck> { new Deck() },0);

            //Act
            var result = dealer.Hand;

            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void Dealer_Should_Have_Dealer_Hand_Score()
        {
            //Arrange
            Dealer dealer = new Dealer(new List<Deck> { new Deck() },0);

            //Act
            var result = dealer.HighestHandScore;

            //Assert
            Assert.IsNotNull(result);
        }


    }
}

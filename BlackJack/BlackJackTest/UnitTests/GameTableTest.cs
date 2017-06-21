using System.Collections.Generic;
using System.Linq;
using BlackJack.Entities;
using BlackJack.Enums;
using NUnit.Framework;

namespace BlackJackTest.UnitTests
{
    [TestFixture]
    public class GameTableTest
    {
        private GameTable.Settlement _Settlement = (dealer, player) => { };

        [Test]
        public void Table_Should_Have_A_Player_And_One_Player()
        {
            //Arrange
            Dealer dealer = new Dealer(new List<Deck>{new Deck()},0);
            Player player = new Player(0);
            //Act
            var table = new GameTable(dealer, player, _Settlement);

            //Assert
            Assert.IsNotNull(table.Dealer);
            Assert.IsNotNull(table.Player);
        }

        [Test]
        public void Game_Start_Dealer_Get_Two_Cards_And_One_Hidden_Player_Get_Two_Cards()
        {
            //Arrange
            Dealer dealer = new Dealer(new List<Deck> { new Deck() },0);
            Player player = new Player(0);

            //Act
            var table = new GameTable(dealer, player,_Settlement);
            table.GameStart();
            //Assert
            Assert.AreEqual(2,table.DealerHand.Count);
            Assert.AreEqual(1,table.DealerHand.Count(x => x.IsHidden));
            Assert.AreEqual(2,table.PlayerHand.Count);
            Assert.AreEqual(Turn.Player,table.Turn);
        }

        [Test]
        public void Game_Start_GameStatus_InProcess()
        {
            //Arrange
            Dealer dealer = new Dealer(new List<Deck> { new Deck() },0);
            Player player = new Player(0);

            //Act
            var table = new GameTable(dealer, player, _Settlement);
            table.GameStart();
            //Assert
            Assert.AreEqual(GameStatus.PlayerInProcess, table.GameStatus);
        }

        [Test]
        public void Player_Turn_Player_Hit_Get_One_Card()
        {
            //Arrange
            Dealer dealer = new Dealer(new List<Deck> { new Deck() },0);
            Player player = new Player(0);

            //Act
            var table = new GameTable(dealer, player, _Settlement);
            table.GameStart();
            table.Hit();
            //Assert
            Assert.AreEqual(3,table.PlayerHand.Count);
        }

        [Test]
        public void Player_Turn_Player_Stay_Become_Dealer_Turn()
        {
            //Arrange
            Dealer dealer = new Dealer(new List<Deck> { new Deck() },0);
            Player player = new Player(0);

            //Act
            var table = new GameTable(dealer, player, _Settlement);
            table.GameStart();
            table.Stay();
            //Assert
            Assert.AreEqual(2,table.PlayerHand.Count);
            Assert.AreEqual(Turn.Dealer,table.Turn);
        }

        [TestCase(16)]
        public void Dealer_Turn_Will_Hit_Until_Larger_Than(int score)
        {
            //Arrange
            Dealer dealer = new Dealer(new List<Deck> { new Deck() },0);
            Player player = new Player(0);

            //Act
            var table = new GameTable(dealer, player, _Settlement);
            table.GameStart();
            table.Stay();
            table.Hit();
            //Assert
            Assert.IsTrue(table.DealerHandScore>16);
        }

        [Test]
        public void Game_End_If_Player_Exceeds_21()
        {
            //Arrange
            Dealer dealer = new Dealer(new List<Deck> { new Deck() },0);
            Player player = new Player(0);

            //Act
            var table = new GameTable(dealer, player, _Settlement);
            table.GameStart();
            while (table.PlayerHandScore<=21)
            {
                table.Hit();
            }
            //Assert
            Assert.AreEqual(GameStatus.End, table.GameStatus);
        }

    }
}

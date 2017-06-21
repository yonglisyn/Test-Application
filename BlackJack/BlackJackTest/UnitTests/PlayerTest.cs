using BlackJack.Entities;
using NUnit.Framework;

namespace BlackJackTest.UnitTests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void Player_Should_Have_Hand()
        {
            //Arrange
            var player= new Player(0);

            //Act
            var result = player.Hand;

            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void Player_Should_Have_Player_Hand_Score()
        {
            //Arrange
            var player= new Player(0);

            //Act
            var result = player.HighestHandScore;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Player_Hit_Add_One_Card()
        {
            //Arrange
            var player= new Player(0);

            //Act
            player.Hit(new Card("2"));

            //Assert
            Assert.AreEqual(1,player.Hand.Count);
        }

        [Test]
        public void Player_HighestHandScore_Ace_As_Eleven_If_Not_Explode()
        {
            //Arrange
            var player= new Player(0);

            //Act
            player.Hit(new Card("A"));
            player.Hit(new Card("J"));

            //Assert
            Assert.AreEqual(21,player.HighestHandScore);
        }

        [Test]
        public void Player_HighestHandScore_Ace_As_Eleven_If_Explode()
        {
            //Arrange
            var player= new Player(0);

            //Act
            player.Hit(new Card("A"));
            player.Hit(new Card("A"));

            //Assert
            Assert.AreEqual(12,player.HighestHandScore);
        }
    }
}

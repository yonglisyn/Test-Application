using BlackJack.Entities;
using NUnit.Framework;

namespace BlackJackTest.UnitTests
{
    [TestFixture]
    public class CardTest
    {
        [TestCase("A",1)]
        [TestCase("10",10)]
        public void Card_Value_Count_Its_Value_For_One_To_Ten(string rank,int expected)
        {
            //Arrange
            var card = new Card(rank);
            //Act
            var result = card.Value;

            //Assert
            Assert.AreEqual(expected,result);
        }

        [TestCase("J")]
        [TestCase("Q")]
        [TestCase("K")]
        public void Card_Value_Count_Ten_For_Faces(string rank)
        {
            //Arrange
            var card = new Card(rank);
            //Act
            var result = card.Value;

            //Assert
            Assert.AreEqual(10,result);
        }
    }
}

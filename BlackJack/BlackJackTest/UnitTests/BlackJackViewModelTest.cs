using System.Collections.Generic;
using System.Linq;
using BlackJack.Entities;
using BlackJack.Enums;
using BlackJack.ViewModels;
using NUnit.Framework;

namespace BlackJackTest.UnitTests
{
    [TestFixture]
    public class BlackJackViewModelTest
    {
        private GameTable.Settlement _Settlement = (dealer, player) => { };

        [Test]
        public void Hidden_Card_Display_As_X()
        {
            //Arrange
            Dealer dealer = new Dealer(new List<Deck> { new Deck() }, 0);
            Player player = new Player(0);
            var table = new GameTable(dealer, player, _Settlement);
            var viewModle = new BlackJackViewModel(table);

            //Act
            table.GameStart();
            var result = viewModle.DealerHand;

            //Assert
            Assert.IsTrue(result.Any(x=>x=="X"));
        }

        //[TestCase(0,true)]
        //[TestCase(1,false)]
        //[TestCase(2,false)]
        //public void Game_Action_Button_Hit_Stay_Only_Show_When_GameStatus_PlayerInProcess(int status,bool expected)
        //{
        //    //Arrange
        //    var table = new FakeGameTable((GameStatus)status);
        //    var viewModle = new BlackJackViewModel(table);

        //    //Act
        //    var result = viewModle.IsShowGameActionButton;

        //    //Assert
        //    Assert.AreEqual(expected,result);
        //}
    }

    public class FakeGameTable:GameTable
    {
        public FakeGameTable(GameStatus status)
            : base(null, null, (dealer, player) => { })
        {
            GameStatus = status;
        }
    }
}

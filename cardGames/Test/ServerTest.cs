using System;
using Google.Protobuf.Protocol;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;
using Server.gameCore;

namespace Test
{
    [TestFixture]
    public class ServerTest
    {
        private static Board _board;

        [OneTimeSetUp]
        public void FixtureSetUp()
        {
            _board = new Board();
        }

        [Test, Order(1)]
        public void Test1_CreateGame()
        {
            Assert.True(_board.NewPlayer("UnitTester1"));
            Assert.True(_board.NewPlayer("UnitTester2"));
            Assert.False(_board.NewPlayer("UnitTester1"));
            Assert.True(_board.GetNbrOfPlayers() == 2);

            _board.CreateGameInstance();

            Response response = _board.PlayCard("UnitTester1");
            Assert.True(response.Type == Response.Types.Type.GameAction);
        }
    }
}
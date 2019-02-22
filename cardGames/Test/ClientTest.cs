using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.Protocol;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class ClientTest
    {
        private Thread _serverThread;
        [OneTimeSetUp]
        public void FixtureSetUp()
        {
            _serverThread = new Thread(async () =>
            {
                await Server.Server.RunServerAsync(); 
            });
            _serverThread.Start();
        }

        [Test, Order(1)]
        public async Task Test1()
        {
            Client.Program.IsRunningUnitTest = true;
            await Client.Program.RunClientAsync();
            
            Client.ClientHandler.ClientHandler.RegisterServer("Unittest");
            Assert.True(GetResponse() == Response.Types.Type.SuccessRegister);
            
            Client.ClientHandler.ClientHandler.RegisterServer("Unittest2");
            Assert.True(GetResponse() == Response.Types.Type.SuccessRegister);
            Assert.True(GetResponse() == Response.Types.Type.Success);
            
            Client.ClientHandler.ClientHandler.RegisterServer("Unittest3");
            Assert.True(GetResponse() == Response.Types.Type.GameAlreadyStarted);
        }

        private static Response.Types.Type GetResponse()
        {
            Response.Types.Type response;

            response = Client.ClientHandler.ClientHandler.GetResponse();
            while (response == Response.Types.Type.Refresh)
            {
                 response = Client.ClientHandler.ClientHandler.GetResponse();
            }
            return response;
        }
        
        [OneTimeTearDown]
        public void FixtureTearDown()
        {
            _serverThread.Interrupt();
        }
    }
}
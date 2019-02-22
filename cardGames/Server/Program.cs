using System;
using System.Threading.Tasks;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Server.gameCore;
using Server.gameCore.Cards;
using Server.ServerInitializer;

namespace Server
{
    public class Server
    {
        private static int _port = 8080;

        public static async Task RunServerAsync()
        {
            var bossGroup = new MultithreadEventLoopGroup(1);
            var workerGroup = new MultithreadEventLoopGroup();

            try
            {
                var bootstrap = new ServerBootstrap();
                bootstrap.Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .Option(ChannelOption.SoBacklog, 100)
                    .Handler(new LoggingHandler(LogLevel.INFO))
                    .ChildHandler(new ServerChannelInitializer());

                Console.WriteLine("Server running on port: " + _port);
                IChannel bootstrapChannel = await bootstrap.BindAsync(_port);
                Console.ReadLine();
                await bootstrapChannel.CloseAsync();
            }
            finally
            {
                Task.WaitAll(bossGroup.ShutdownGracefullyAsync(), workerGroup.ShutdownGracefullyAsync());
            }
        }

        public static void Main(string[] args)
        {
            if (args.Length >= 1)
                _port = int.Parse(args[0]);
            RunServerAsync().Wait();
        }
    }
}
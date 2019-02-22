using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Client.ClientInitializer;
using DotNetty.Codecs;
using DotNetty.Handlers.Tls;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Google.Protobuf.Protocol;

namespace Client
{
    public class Program
    {
        private static string _ipaddr = "127.0.0.1";
        private static int _port = 8080;
        private static string _username;
        private static bool isRunningUnitTest = false;
        private static IChannel bootstrapChannel;

        public static async Task RunClientAsync()
        {
            var group = new MultithreadEventLoopGroup();
            var bootstrap = new Bootstrap();

            try
            {
                bootstrap
                    .Group(group)
                    .Channel<TcpSocketChannel>()
                    .Option(ChannelOption.TcpNodelay, true)
                    .Handler(new ClientChannelInitializer());

                IPAddress address = IPAddress.Parse(_ipaddr);
                bootstrapChannel = await bootstrap.ConnectAsync(new IPEndPoint(address, _port));
                if (!isRunningUnitTest)
                {
                    GetUserInfos();
                    ClientHandler.ClientHandler.RegisterServer(_username);
                    ClientHandler.ClientHandler.WaitUserEntry();
                    await bootstrapChannel.CloseAsync();    
                }
                
            }
            finally
            {
                if (!isRunningUnitTest)
                    group.ShutdownGracefullyAsync().Wait(1000);
            }
        }

        public static void Main(string[] args)
        {
            if (args.Length == 1)
                _port = int.Parse(args[0]);
            else if (args.Length == 2)
            {
                _port = int.Parse(args[0]);
                _ipaddr = args[1];
            }
            RunClientAsync().Wait();
        }

        public static void GetUserInfos()
        {
            string entry = "";

            Console.Write("Enter your username: ");
            while (entry != null && entry.Length == 0)
            {
                entry = Console.ReadLine();
            }
            _username = entry;
        }

        public static string GetUsername()
        {
            return _username;
        }
         
        public static bool IsRunningUnitTest
        {
            set => isRunningUnitTest = value;
        }
        
       
        public static IChannel BootstrapChannel => bootstrapChannel;
    }
}
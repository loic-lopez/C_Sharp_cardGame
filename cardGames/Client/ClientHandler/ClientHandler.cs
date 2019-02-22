using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Client.Library;
using DotNetty.Transport.Channels;
using Google.Protobuf.Protocol;
using DotNetty.Transport.Channels.Embedded;

namespace Client.ClientHandler
{
    public class ClientHandler : SimpleChannelInboundHandler<Response>
    {
        private static ConcurrentQueue<Response> _queue = new ConcurrentQueue<Response>();
        private static IChannel _channel;
        private static Response _response = new Response();
        private static string _username;

        public static Response.Types.Type GetResponse()
        {
            if (_queue.TryDequeue(out _response))
            {
                switch (_response.Type)
                {
                    case Response.Types.Type.ServerShutdown:
                    {
                        Utils.ConsoleColors.PrintWithColor(_response.ResponseMsg, ConsoleColor.Yellow);
                        return _response.Type;
                    }
                    case Response.Types.Type.GameAlreadyStarted:
                    {
                        PrintConsoleBuffered();
                        Console.WriteLine(_response.ResponseMsg);
                        return _response.Type;
                    }
                    case Response.Types.Type.GameAction:
                    {
                        PrintConsoleBuffered();
                        Console.WriteLine(_response.ResponseMsg);
                        return _response.Type;
                    }
                    case Response.Types.Type.Disconnect:
                    case Response.Types.Type.Success:
                    {
                        Utils.ConsoleColors.PrintWithColor(_response.ResponseMsg, ConsoleColor.Green);
                        return _response.Type;
                    }
                    case Response.Types.Type.Failed:
                    {
                        Utils.ConsoleColors.PrintWithColor(_response.ResponseMsg, ConsoleColor.Red);
                        return _response.Type;
                    }
                    case Response.Types.Type.SuccessRegister:
                    {
                        Utils.ConsoleColors.PrintWithColor(_response.ResponseMsg, ConsoleColor.Cyan);
                        return _response.Type;
                    }
                    case Response.Types.Type.UsernameAlreadyTaken:
                    {
                        Utils.ConsoleColors.PrintWithColor(_response.ResponseMsg, ConsoleColor.Blue);
                        return _response.Type;
                    }
                    case Response.Types.Type.Help:
                    {
                        List<HelpCommand> helpCommands = _response.Help.ToList();
                        Utils.ConsoleColors.PrintWithColor(_response.ResponseMsg, ConsoleColor.Green);
                        foreach (var helpCommand in helpCommands)
                        {
                            Utils.ConsoleColors.PrintWithColor(helpCommand.Name + ": ", ConsoleColor.Yellow, false);
                            Utils.ConsoleColors.PrintWithColor(helpCommand.Description, ConsoleColor.Green);
                        }
                        return _response.Type;
                    }
                    case Response.Types.Type.CurrentCardPlayed:
                    {
                        List<string> card = _response.CurrentCardPlayed.ToList();
                        Utils.ConsoleColors.PrintWithColor(_response.ResponseMsg, ConsoleColor.Green);
                        Utils.ConsoleColors.PrintWithColor(card.ElementAt(0) + ": ", ConsoleColor.Yellow, false);
                        Utils.ConsoleColors.PrintWithColor(card.ElementAt(1), ConsoleColor.Green);
                        return _response.Type;
                    }
                    case Response.Types.Type.ResetGame:
                    {
                        PrintConsoleBuffered();
                        Console.WriteLine(_response.ResponseMsg);
                        return _response.Type;
                    }
                }
            }
            return Response.Types.Type.Refresh;
        }

        public static void WaitUserEntry()
        {
            string buffer;
            Utils.ConsoleReader consoleReader = new Utils.ConsoleReader();

            consoleReader.Start();
            while (true)
            {
                Response.Types.Type type = GetResponse();
                switch (type)
                {
                    case Response.Types.Type.GameAlreadyStarted:
                    case Response.Types.Type.Disconnect:
                    case Response.Types.Type.ServerShutdown:
                        goto breakMainloop;
                    case Response.Types.Type.UsernameAlreadyTaken:
                    {
                        Program.GetUserInfos();
                        RegisterServer(Program.GetUsername());
                        break;
                    }
                }

                if (type != Response.Types.Type.Refresh)
                    PrintConsoleBuffered();
                if (consoleReader.DataReceived())
                {
                    buffer = consoleReader.Take();
                    if (buffer.Length > 0)
                        CheckEntry(buffer, _username);
                    PrintConsoleBuffered();
                }
            }
            breakMainloop:
            consoleReader.Shutdown();
        }

        private static void CheckEntry(string entry, string username)
        {
            List<string> commands = new List<string>(entry.Split(' '));
            commands.RemoveAll(item => item == null);
            commands.RemoveAll(item => item == "");
            commands = commands.ConvertAll(d => d.ToLower());

            string insruction = commands.ElementAt(0);
            commands.RemoveAt(0);
            switch (insruction)
            {
                case "play":
                {
                    SendRequest(username, Request.Types.Type.PlayACard, commands);
                    break;
                }
                case "disconnect":
                {
                    SendRequest(username, Request.Types.Type.Disconnect, commands);
                    break;
                }
                case "board":
                {
                    SendRequest(username, Request.Types.Type.CurrentCardPlayed, commands);
                    break;
                }
                default:
                {
                    SendRequest(username, Request.Types.Type.Help, commands);
                    break;
                }
            }
        }

        private static void SendRequest(string username, Request.Types.Type type, IReadOnlyCollection<string> param)
        {
            Request request = new Request();

            if (param != null)
                request.Command.Add(param);
            request.Type = type;
            request.Username = username;
            _channel.WriteAndFlushAsync(request);
        }

        public static void RegisterServer(string username)
        {
            Request request = new Request
            {
                Type = Request.Types.Type.Register,
                Username = username
            };
            _channel.WriteAndFlushAsync(request);
            _username = username;
        }

        public override void ChannelRegistered(IChannelHandlerContext context)
        {
            _channel = context.Channel;
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, Response msg)
        {
            _queue.Enqueue(msg);
        }

        public override void ExceptionCaught(IChannelHandlerContext contex, Exception e)
        {
            Console.WriteLine(DateTime.Now.Millisecond);
            Console.WriteLine(e.StackTrace);
            contex.CloseAsync();
        }

        private static void PrintConsole()
        {
            Console.WriteLine("Battle-> ");
        }

        private static void PrintConsoleBuffered()
        {
            Console.Write("Battle-> ");
        }
    }
}
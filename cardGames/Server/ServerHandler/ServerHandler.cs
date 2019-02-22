using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Groups;
using Google.Protobuf.Protocol;
using Newtonsoft.Json;
using Server.gameCore;

namespace Server.ServerHandler
{
    public class ServerHandler : SimpleChannelInboundHandler<Request>
    {
        static volatile IChannelGroup _group;
        private static Board _board = new Board();


        public override void ChannelActive(IChannelHandlerContext contex)
        {
            var g = _group;
            if (g == null)
            {
                lock (this)
                {
                    if (_group == null)
                    {
                        g = _group = new DefaultChannelGroup(contex.Executor);
                    }
                }
            }

            g?.Add(contex.Channel);
        }

        private static List<HelpCommand> buildHelpCommands()
        {
            List<HelpCommand> commands = new List<HelpCommand>();
            HelpCommand helpCommand = new HelpCommand();

            using (StreamReader r = new StreamReader("ServerHandler/HelpCommandConfig.json"))
            {
                string json = r.ReadToEnd();
                var helpCommands = JsonConvert.DeserializeObject<Dictionary<int, Dictionary<string, string>>>(json);

                foreach (var helpCommandJsonObject in helpCommands)
                {
                    foreach (var jsonObject in helpCommandJsonObject.Value)
                    {
                        if (jsonObject.Key.Equals("Name"))
                            helpCommand = new HelpCommand {Name = jsonObject.Value};
                        else if (jsonObject.Key.Equals("Description"))
                        {
                            helpCommand.Description = jsonObject.Value;
                            commands.Add(helpCommand);
                        }
                    }
                }
            }

            return commands;
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, Request msg)
        {
            List<string> command = msg.Command.ToList();

            Response response = new Response();
            if (msg.Type == Request.Types.Type.Disconnect)
            {
                response.ResponseMsg = "See you later!";
                response.Type = Response.Types.Type.Disconnect;
                _board.RemovePlayer(msg.Username);
                ctx.Channel.WriteAndFlushAsync(response);
            }
            else if (msg.Type == Request.Types.Type.Help)
            {
                response.ResponseMsg = "Available commands: ";
                response.Type = Response.Types.Type.Help;
                foreach (var helpcmd in buildHelpCommands())
                    response.Help.Add(helpcmd);
                ctx.Channel.WriteAndFlushAsync(response);
            }
            else if (_board.GetNbrOfPlayers() < Board.MaxPlayers)
            {
                if (msg.Type == Request.Types.Type.Register)
                {
                    if (!_board.NewPlayer(msg.Username))
                    {
                        response.ResponseMsg = "Username already taken!";
                        response.Type = Response.Types.Type.UsernameAlreadyTaken;
                    }
                    else
                    {
                        response.ResponseMsg = "You have been registred. Welcome.";
                        response.Type = Response.Types.Type.SuccessRegister;
                    }
                    ctx.Channel.WriteAndFlushAsync(response);
                    if (_board.GetNbrOfPlayers() == Board.MaxPlayers)
                    {
                        _board.CreateGameInstance();
                        response.ResponseMsg = "Let the game begins!";
                        response.Type = Response.Types.Type.Success;
                        _group.WriteAndFlushAsync(response);
                    }
                }
                else
                {
                    response.ResponseMsg = "Not enough player.";
                    response.Type = Response.Types.Type.Failed;
                    ctx.Channel.WriteAndFlushAsync(response);
                }
            }
            else
            {
                if (msg.Type == Request.Types.Type.Register)
                {
                    response.ResponseMsg = "Game is already launched.";
                    response.Type = Response.Types.Type.GameAlreadyStarted;
                    ctx.Channel.WriteAndFlushAsync(response);
                }
                else if (msg.Type == Request.Types.Type.CurrentCardPlayed)
                {
                    response.ResponseMsg = "Current card on board:";
                    foreach (var s in _board.GetLastPlayedCard())
                        response.CurrentCardPlayed.Add(s);
                    response.Type = Response.Types.Type.CurrentCardPlayed;
                    ctx.Channel.WriteAndFlushAsync(response);
                }
                else if (CheckTurn(msg))
                {
                    switch (msg.Type)
                    {
                        case Request.Types.Type.PlayACard:
                        {
                            response = _board.PlayCard(msg.Username);
                            if (response.Type == Response.Types.Type.Failed)
                                ctx.Channel.WriteAndFlushAsync(response);
                            else
                            {
                                _group.WriteAndFlushAsync(response);
                                response = _board.PassTurn(msg.Username);
                                _group.WriteAndFlushAsync(response);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    response.ResponseMsg = "Please wait your turn.";
                    response.Type = Response.Types.Type.Failed;
                    ctx.Channel.WriteAndFlushAsync(response);
                }
            }
        }

        public override void ChannelReadComplete(IChannelHandlerContext ctx) => ctx.Flush();

        private static bool CheckTurn(Request msg)
        {
            return _board.CanPlay(msg.Username);
        }
    }
}
using System;
using DotNetty.Codecs.Protobuf;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace Client.ClientInitializer
{
    public class ClientChannelInitializer : ChannelInitializer<ISocketChannel>
    {
        protected override void InitChannel(ISocketChannel channel)
        {
            var pipeline = channel.Pipeline;
            if (pipeline == null) throw new ArgumentNullException(nameof(pipeline));

            pipeline.AddLast(new ProtobufVarint32FrameDecoder());
            pipeline.AddLast(new ProtobufDecoder(Google.Protobuf.Protocol.Response.Parser));
            pipeline.AddLast(new ProtobufVarint32LengthFieldPrepender());
            pipeline.AddLast(new ProtobufEncoder());
            pipeline.AddLast(new ClientHandler.ClientHandler());
        }
    }
}
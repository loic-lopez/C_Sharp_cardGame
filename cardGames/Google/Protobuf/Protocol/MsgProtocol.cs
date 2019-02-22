// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: RawProtocol/MsgProtocol.proto

#pragma warning disable 1591, 0612, 3021

#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;

namespace Google.Protobuf.Protocol
{
    /// <summary>Holder for reflection information generated from RawProtocol/MsgProtocol.proto</summary>
    public static partial class MsgProtocolReflection
    {
        #region Descriptor

        /// <summary>File descriptor for RawProtocol/MsgProtocol.proto</summary>
        public static pbr::FileDescriptor Descriptor
        {
            get { return descriptor; }
        }

        private static pbr::FileDescriptor descriptor;

        static MsgProtocolReflection()
        {
            byte[] descriptorData = global::System.Convert.FromBase64String(
                string.Concat(
                    "Ch1SYXdQcm90b2NvbC9Nc2dQcm90b2NvbC5wcm90bxIIUHJvdG9idWYirAEK",
                    "B1JlcXVlc3QSJAoEdHlwZRgBIAEoDjIWLlByb3RvYnVmLlJlcXVlc3QuVHlw",
                    "ZRIPCgdjb21tYW5kGAIgAygJEhAKCFVzZXJuYW1lGAMgASgJIlgKBFR5cGUS",
                    "DAoIUkVHSVNURVIQABIPCgtQTEFZX0FfQ0FSRBABEg4KCkRJU0NPTk5FQ1QQ",
                    "AhIICgRIRUxQEAMSFwoTQ1VSUkVOVF9DQVJEX1BMQVlFRBAEIicKBENhcmQS",
                    "DQoFY29sb3IYASABKAkSEAoIY2FyZE5hbWUYAiABKAkiMAoLSGVscENvbW1h",
                    "bmQSDAoEbmFtZRgBIAEoCRITCgtkZXNjcmlwdGlvbhgCIAEoCSL/AgoIUmVz",
                    "cG9uc2USJQoEdHlwZRgBIAEoDjIXLlByb3RvYnVmLlJlc3BvbnNlLlR5cGUS",
                    "EwoLcmVzcG9uc2VNc2cYAiABKAkSIwoEaGVscBgDIAMoCzIVLlByb3RvYnVm",
                    "LkhlbHBDb21tYW5kEhsKE2N1cnJlbnRfY2FyZF9wbGF5ZWQYBCADKAki9AEK",
                    "BFR5cGUSBwoDV0lOEAASCAoETE9TRRABEgsKB1JFRlJFU0gQAhIOCgpSRVNF",
                    "VF9HQU1FEAMSCwoHU1VDQ0VTUxAEEgoKBkZBSUxFRBAFEhQKEFNVQ0NFU1Nf",
                    "UkVHSVNURVIQBhITCg9TRVJWRVJfU0hVVERPV04QBxIYChRHQU1FX0FMUkVB",
                    "RFlfU1RBUlRFRBAIEg4KCkRJU0NPTk5FQ1QQCRIaChZVU0VSTkFNRV9BTFJF",
                    "QURZX1RBS0VOEAoSDwoLR0FNRV9BQ1RJT04QCxIICgRIRUxQEAwSFwoTQ1VS",
                    "UkVOVF9DQVJEX1BMQVlFRBANQh1IAaoCGEdvb2dsZS5Qcm90b2J1Zi5Qcm90",
                    "b2NvbGIGcHJvdG8z"));
            descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
                new pbr::FileDescriptor[] { },
                new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[]
                {
                    new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.Request),
                        global::Google.Protobuf.Protocol.Request.Parser, new[] {"Type", "Command", "Username"}, null,
                        new[] {typeof(global::Google.Protobuf.Protocol.Request.Types.Type)}, null),
                    new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.Card),
                        global::Google.Protobuf.Protocol.Card.Parser, new[] {"Color", "CardName"}, null, null, null),
                    new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.HelpCommand),
                        global::Google.Protobuf.Protocol.HelpCommand.Parser, new[] {"Name", "Description"}, null, null,
                        null),
                    new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.Response),
                        global::Google.Protobuf.Protocol.Response.Parser,
                        new[] {"Type", "ResponseMsg", "Help", "CurrentCardPlayed"}, null,
                        new[] {typeof(global::Google.Protobuf.Protocol.Response.Types.Type)}, null)
                }));
        }

        #endregion
    }

    #region Messages

    public sealed partial class Request : pb::IMessage<Request>
    {
        private static readonly pb::MessageParser<Request> _parser = new pb::MessageParser<Request>(() => new Request())
            ;

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<Request> Parser
        {
            get { return _parser; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::Google.Protobuf.Protocol.MsgProtocolReflection.Descriptor.MessageTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Request()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Request(Request other) : this()
        {
            type_ = other.type_;
            command_ = other.command_.Clone();
            username_ = other.username_;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Request Clone()
        {
            return new Request(this);
        }

        /// <summary>Field number for the "type" field.</summary>
        public const int TypeFieldNumber = 1;

        private global::Google.Protobuf.Protocol.Request.Types.Type type_ = 0;

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Protocol.Request.Types.Type Type
        {
            get { return type_; }
            set { type_ = value; }
        }

        /// <summary>Field number for the "command" field.</summary>
        public const int CommandFieldNumber = 2;

        private static readonly pb::FieldCodec<string> _repeated_command_codec
            = pb::FieldCodec.ForString(18);

        private readonly pbc::RepeatedField<string> command_ = new pbc::RepeatedField<string>();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<string> Command
        {
            get { return command_; }
        }

        /// <summary>Field number for the "Username" field.</summary>
        public const int UsernameFieldNumber = 3;

        private string username_ = "";

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Username
        {
            get { return username_; }
            set { username_ = pb::ProtoPreconditions.CheckNotNull(value, "value"); }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as Request);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Request other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Type != other.Type) return false;
            if (!command_.Equals(other.command_)) return false;
            if (Username != other.Username) return false;
            return true;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (Type != 0) hash ^= Type.GetHashCode();
            hash ^= command_.GetHashCode();
            if (Username.Length != 0) hash ^= Username.GetHashCode();
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (Type != 0)
            {
                output.WriteRawTag(8);
                output.WriteEnum((int) Type);
            }
            command_.WriteTo(output, _repeated_command_codec);
            if (Username.Length != 0)
            {
                output.WriteRawTag(26);
                output.WriteString(Username);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (Type != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Type);
            }
            size += command_.CalculateSize(_repeated_command_codec);
            if (Username.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeStringSize(Username);
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Request other)
        {
            if (other == null)
            {
                return;
            }
            if (other.Type != 0)
            {
                Type = other.Type;
            }
            command_.Add(other.command_);
            if (other.Username.Length != 0)
            {
                Username = other.Username;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        input.SkipLastField();
                        break;
                    case 8:
                    {
                        type_ = (global::Google.Protobuf.Protocol.Request.Types.Type) input.ReadEnum();
                        break;
                    }
                    case 18:
                    {
                        command_.AddEntriesFrom(input, _repeated_command_codec);
                        break;
                    }
                    case 26:
                    {
                        Username = input.ReadString();
                        break;
                    }
                }
            }
        }

        #region Nested types

        /// <summary>Container for nested types declared in the Request message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types
        {
            public enum Type
            {
                [pbr::OriginalName("REGISTER")] Register = 0,
                [pbr::OriginalName("PLAY_A_CARD")] PlayACard = 1,
                [pbr::OriginalName("DISCONNECT")] Disconnect = 2,
                [pbr::OriginalName("HELP")] Help = 3,
                [pbr::OriginalName("CURRENT_CARD_PLAYED")] CurrentCardPlayed = 4,
            }
        }

        #endregion
    }

    public sealed partial class Card : pb::IMessage<Card>
    {
        private static readonly pb::MessageParser<Card> _parser = new pb::MessageParser<Card>(() => new Card());

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<Card> Parser
        {
            get { return _parser; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::Google.Protobuf.Protocol.MsgProtocolReflection.Descriptor.MessageTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Card()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Card(Card other) : this()
        {
            color_ = other.color_;
            cardName_ = other.cardName_;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Card Clone()
        {
            return new Card(this);
        }

        /// <summary>Field number for the "color" field.</summary>
        public const int ColorFieldNumber = 1;

        private string color_ = "";

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Color
        {
            get { return color_; }
            set { color_ = pb::ProtoPreconditions.CheckNotNull(value, "value"); }
        }

        /// <summary>Field number for the "cardName" field.</summary>
        public const int CardNameFieldNumber = 2;

        private string cardName_ = "";

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string CardName
        {
            get { return cardName_; }
            set { cardName_ = pb::ProtoPreconditions.CheckNotNull(value, "value"); }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as Card);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Card other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Color != other.Color) return false;
            if (CardName != other.CardName) return false;
            return true;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (Color.Length != 0) hash ^= Color.GetHashCode();
            if (CardName.Length != 0) hash ^= CardName.GetHashCode();
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (Color.Length != 0)
            {
                output.WriteRawTag(10);
                output.WriteString(Color);
            }
            if (CardName.Length != 0)
            {
                output.WriteRawTag(18);
                output.WriteString(CardName);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (Color.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeStringSize(Color);
            }
            if (CardName.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeStringSize(CardName);
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Card other)
        {
            if (other == null)
            {
                return;
            }
            if (other.Color.Length != 0)
            {
                Color = other.Color;
            }
            if (other.CardName.Length != 0)
            {
                CardName = other.CardName;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        input.SkipLastField();
                        break;
                    case 10:
                    {
                        Color = input.ReadString();
                        break;
                    }
                    case 18:
                    {
                        CardName = input.ReadString();
                        break;
                    }
                }
            }
        }
    }

    public sealed partial class HelpCommand : pb::IMessage<HelpCommand>
    {
        private static readonly pb::MessageParser<HelpCommand> _parser =
            new pb::MessageParser<HelpCommand>(() => new HelpCommand());

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<HelpCommand> Parser
        {
            get { return _parser; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::Google.Protobuf.Protocol.MsgProtocolReflection.Descriptor.MessageTypes[2]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public HelpCommand()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public HelpCommand(HelpCommand other) : this()
        {
            name_ = other.name_;
            description_ = other.description_;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public HelpCommand Clone()
        {
            return new HelpCommand(this);
        }

        /// <summary>Field number for the "name" field.</summary>
        public const int NameFieldNumber = 1;

        private string name_ = "";

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Name
        {
            get { return name_; }
            set { name_ = pb::ProtoPreconditions.CheckNotNull(value, "value"); }
        }

        /// <summary>Field number for the "description" field.</summary>
        public const int DescriptionFieldNumber = 2;

        private string description_ = "";

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Description
        {
            get { return description_; }
            set { description_ = pb::ProtoPreconditions.CheckNotNull(value, "value"); }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as HelpCommand);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(HelpCommand other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Name != other.Name) return false;
            if (Description != other.Description) return false;
            return true;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (Name.Length != 0) hash ^= Name.GetHashCode();
            if (Description.Length != 0) hash ^= Description.GetHashCode();
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (Name.Length != 0)
            {
                output.WriteRawTag(10);
                output.WriteString(Name);
            }
            if (Description.Length != 0)
            {
                output.WriteRawTag(18);
                output.WriteString(Description);
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (Name.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
            }
            if (Description.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
            }
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(HelpCommand other)
        {
            if (other == null)
            {
                return;
            }
            if (other.Name.Length != 0)
            {
                Name = other.Name;
            }
            if (other.Description.Length != 0)
            {
                Description = other.Description;
            }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        input.SkipLastField();
                        break;
                    case 10:
                    {
                        Name = input.ReadString();
                        break;
                    }
                    case 18:
                    {
                        Description = input.ReadString();
                        break;
                    }
                }
            }
        }
    }

    public sealed partial class Response : pb::IMessage<Response>
    {
        private static readonly pb::MessageParser<Response> _parser =
            new pb::MessageParser<Response>(() => new Response());

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<Response> Parser
        {
            get { return _parser; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor
        {
            get { return global::Google.Protobuf.Protocol.MsgProtocolReflection.Descriptor.MessageTypes[3]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor
        {
            get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Response()
        {
            OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Response(Response other) : this()
        {
            type_ = other.type_;
            responseMsg_ = other.responseMsg_;
            help_ = other.help_.Clone();
            currentCardPlayed_ = other.currentCardPlayed_.Clone();
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public Response Clone()
        {
            return new Response(this);
        }

        /// <summary>Field number for the "type" field.</summary>
        public const int TypeFieldNumber = 1;

        private global::Google.Protobuf.Protocol.Response.Types.Type type_ = 0;

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.Protocol.Response.Types.Type Type
        {
            get { return type_; }
            set { type_ = value; }
        }

        /// <summary>Field number for the "responseMsg" field.</summary>
        public const int ResponseMsgFieldNumber = 2;

        private string responseMsg_ = "";

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string ResponseMsg
        {
            get { return responseMsg_; }
            set { responseMsg_ = pb::ProtoPreconditions.CheckNotNull(value, "value"); }
        }

        /// <summary>Field number for the "help" field.</summary>
        public const int HelpFieldNumber = 3;

        private static readonly pb::FieldCodec<global::Google.Protobuf.Protocol.HelpCommand> _repeated_help_codec
            = pb::FieldCodec.ForMessage(26, global::Google.Protobuf.Protocol.HelpCommand.Parser);

        private readonly pbc::RepeatedField<global::Google.Protobuf.Protocol.HelpCommand> help_ =
            new pbc::RepeatedField<global::Google.Protobuf.Protocol.HelpCommand>();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<global::Google.Protobuf.Protocol.HelpCommand> Help
        {
            get { return help_; }
        }

        /// <summary>Field number for the "current_card_played" field.</summary>
        public const int CurrentCardPlayedFieldNumber = 4;

        private static readonly pb::FieldCodec<string> _repeated_currentCardPlayed_codec
            = pb::FieldCodec.ForString(34);

        private readonly pbc::RepeatedField<string> currentCardPlayed_ = new pbc::RepeatedField<string>();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pbc::RepeatedField<string> CurrentCardPlayed
        {
            get { return currentCardPlayed_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other)
        {
            return Equals(other as Response);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(Response other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(other, this))
            {
                return true;
            }
            if (Type != other.Type) return false;
            if (ResponseMsg != other.ResponseMsg) return false;
            if (!help_.Equals(other.help_)) return false;
            if (!currentCardPlayed_.Equals(other.currentCardPlayed_)) return false;
            return true;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode()
        {
            int hash = 1;
            if (Type != 0) hash ^= Type.GetHashCode();
            if (ResponseMsg.Length != 0) hash ^= ResponseMsg.GetHashCode();
            hash ^= help_.GetHashCode();
            hash ^= currentCardPlayed_.GetHashCode();
            return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString()
        {
            return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output)
        {
            if (Type != 0)
            {
                output.WriteRawTag(8);
                output.WriteEnum((int) Type);
            }
            if (ResponseMsg.Length != 0)
            {
                output.WriteRawTag(18);
                output.WriteString(ResponseMsg);
            }
            help_.WriteTo(output, _repeated_help_codec);
            currentCardPlayed_.WriteTo(output, _repeated_currentCardPlayed_codec);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize()
        {
            int size = 0;
            if (Type != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Type);
            }
            if (ResponseMsg.Length != 0)
            {
                size += 1 + pb::CodedOutputStream.ComputeStringSize(ResponseMsg);
            }
            size += help_.CalculateSize(_repeated_help_codec);
            size += currentCardPlayed_.CalculateSize(_repeated_currentCardPlayed_codec);
            return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(Response other)
        {
            if (other == null)
            {
                return;
            }
            if (other.Type != 0)
            {
                Type = other.Type;
            }
            if (other.ResponseMsg.Length != 0)
            {
                ResponseMsg = other.ResponseMsg;
            }
            help_.Add(other.help_);
            currentCardPlayed_.Add(other.currentCardPlayed_);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input)
        {
            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                switch (tag)
                {
                    default:
                        input.SkipLastField();
                        break;
                    case 8:
                    {
                        type_ = (global::Google.Protobuf.Protocol.Response.Types.Type) input.ReadEnum();
                        break;
                    }
                    case 18:
                    {
                        ResponseMsg = input.ReadString();
                        break;
                    }
                    case 26:
                    {
                        help_.AddEntriesFrom(input, _repeated_help_codec);
                        break;
                    }
                    case 34:
                    {
                        currentCardPlayed_.AddEntriesFrom(input, _repeated_currentCardPlayed_codec);
                        break;
                    }
                }
            }
        }

        #region Nested types

        /// <summary>Container for nested types declared in the Response message type.</summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static partial class Types
        {
            public enum Type
            {
                [pbr::OriginalName("WIN")] Win = 0,
                [pbr::OriginalName("LOSE")] Lose = 1,
                [pbr::OriginalName("REFRESH")] Refresh = 2,
                [pbr::OriginalName("RESET_GAME")] ResetGame = 3,
                [pbr::OriginalName("SUCCESS")] Success = 4,
                [pbr::OriginalName("FAILED")] Failed = 5,
                [pbr::OriginalName("SUCCESS_REGISTER")] SuccessRegister = 6,
                [pbr::OriginalName("SERVER_SHUTDOWN")] ServerShutdown = 7,
                [pbr::OriginalName("GAME_ALREADY_STARTED")] GameAlreadyStarted = 8,
                [pbr::OriginalName("DISCONNECT")] Disconnect = 9,
                [pbr::OriginalName("USERNAME_ALREADY_TAKEN")] UsernameAlreadyTaken = 10,
                [pbr::OriginalName("GAME_ACTION")] GameAction = 11,
                [pbr::OriginalName("HELP")] Help = 12,
                [pbr::OriginalName("CURRENT_CARD_PLAYED")] CurrentCardPlayed = 13,
            }
        }

        #endregion
    }

    #endregion
}

#endregion Designer generated code
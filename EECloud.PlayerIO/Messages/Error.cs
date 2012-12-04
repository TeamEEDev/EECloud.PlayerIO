using System;
using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    public class Error
    {
        [ProtoMember(1)]
        public ErrorCode ErrorCode;

        [ProtoMember(2)]
        public string Message;

        public Error()
        {
            ErrorCode = ErrorCode.InternalError;
        }
    }
}

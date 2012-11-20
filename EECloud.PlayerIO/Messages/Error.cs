using System;
using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    [Serializable]
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

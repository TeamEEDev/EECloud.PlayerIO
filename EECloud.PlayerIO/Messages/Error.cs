using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    public class Error
    {
        [ProtoMember(1)]
        public ErrorCode ErrorCode { get; set; }

        [ProtoMember(2)]
        public string Message { get; set; }

        public Error()
        {
            ErrorCode = ErrorCode.InternalError;
        }
    }
}

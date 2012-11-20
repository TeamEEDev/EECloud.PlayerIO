using System;
using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    [Serializable]
    public class RegistrationError
    {
        [ProtoMember(1)]
        public ErrorCode ErrorCode;

        [ProtoMember(2)]
        public string Message;

        [ProtoMember(3)]
        public string UsernameError;

        [ProtoMember(4)]
        public string PasswordError;

        [ProtoMember(5)]
        public string EmailError;

        [ProtoMember(6)]
        public string CaptchaError;

        public RegistrationError()
        {
            ErrorCode = ErrorCode.InternalError;
        }
    }
}

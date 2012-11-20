using System;

namespace EECloud.PlayerIO
{
    public class PlayerIOError : ApplicationException
    {
        public ErrorCode ErrorCode
        {
            get;
            private set;
        }

        public PlayerIOError(ErrorCode errorCode, string message)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}

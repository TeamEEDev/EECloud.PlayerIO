using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    public class KongregateConnectArgs
    {
        [ProtoMember(3)]
        public string GameAuthToken
        {
            get;
            set;
        }

        [ProtoMember(1)]
        public string GameId
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string UserId
        {
            get;
            set;
        }
    }
}

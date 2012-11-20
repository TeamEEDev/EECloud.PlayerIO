using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    public class CreateJoinRoomOutput
    {
        [ProtoMember(3)]
        public GClass9.ServerEndpoint[] Endpoints
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string JoinKey
        {
            get;
            set;
        }

        [ProtoMember(1)]
        public string RoomId
        {
            get;
            set;
        }

    }
}

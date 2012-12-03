using System.Collections.Generic;
using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    public class ListRoomsOutput
    {
        [ProtoMember(1)]
        public List<RoomInfo> RoomInfo
        {
            get;
            set;
        }
    }
}

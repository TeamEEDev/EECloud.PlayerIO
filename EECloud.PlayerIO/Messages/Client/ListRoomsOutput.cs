using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    public class ListRoomsOutput
    {
        [ProtoMember(1)]
        public RoomInfo[] RoomInfo { get; set; }
    }
}

using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    internal class ListRoomsOutput
    {
        [ProtoMember(1)]
        public RoomInfo[] RoomInfo { get; set; }
    }
}

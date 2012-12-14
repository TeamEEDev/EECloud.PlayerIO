using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    public class JoinRoomArgs
    {
        [ProtoMember(1)]
        public string RoomId { get; set; }

        [ProtoMember(2)]
        public KeyValuePair[] JoinData { get; set; }

        [ProtoMember(3)]
        public bool IsDevRoom { get; set; }
    }
}

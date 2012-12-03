using System.Collections.Generic;

namespace EECloud.PlayerIO
{
    public class RoomInfo
    {
        public string Id
        {
            get;
            private set;
        }

        public string RoomType
        {
            get;
            private set;
        }

        public int OnlineUsers
        {
            get;
            private set;
        }

        /// <summary>The current room data for the room.</summary>
        public Dictionary<string, string> RoomData
        {
            get;
            private set;
        }

        internal RoomInfo(string id, string roomType, int onlineUsers, Dictionary<string, string> roomData)
        {
            Id = id;
            RoomType = roomType;
            OnlineUsers = onlineUsers;
            RoomData = (roomData ?? new Dictionary<string, string>());
        }
    }
}

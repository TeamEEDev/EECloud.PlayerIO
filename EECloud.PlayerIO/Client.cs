using System.Collections.Generic;
using EECloud.PlayerIO.Messages;

namespace EECloud.PlayerIO
{
    /// <summary>
    /// Represents a client you can access the various Player.IO services with.
    /// </summary>
    public class Client
    {
        private readonly HttpChannel _channel;

        public BigDB BigDB { get; private set; }

        /// <summary>
        /// If not null, rooms will be created on the development server at the address defined by the server endpoint, instead of using the live Player.IO servers.
        /// </summary>
        public ServerEndpoint DevelopmentServer;

        private readonly string _connectUserId;
        public string ConnectUserId
        {
            get { return _connectUserId; }
        }

        private readonly string _token;
        public string Token
        {
            get { return _token; }
        }

        internal Client(HttpChannel channel, string token, string connectUserId)
        {
            channel.SetToken(token);
            _channel = channel;
            BigDB = new BigDB(channel);
            _token = token;
            _connectUserId = connectUserId;
        }

        /// <summary>
        /// Creates a multiplayer room (if it doesn't exists already), and joins it.
        /// </summary>
        /// <param name="roomId">The ID of the room you wish to (create and then) join.</param>
        /// <param name="serverType">If the room doesn't exists: The name of the room type you wish to run the room as. This value should match one of the 'RoomType(...)' attributes of your uploaded code. A room type of 'bounce' is always available.</param>
        /// <param name="visible">If the room doesn't exists: Determines (upon creation) if the room should be visible when listing rooms with GetRooms.</param>
        /// <param name="roomData">If the room doesn't exists: The data to initialize the room with (upon creation).</param>
        /// <param name="joinData">Data to send to the room with additional information about the join.</param>
        public Connection CreateJoinRoom(string roomId, string serverType, bool visible = true, Dictionary<string, string> roomData = null, Dictionary<string, string> joinData = null)
        {
            var createJoinRoomArg = new CreateJoinRoomArgs
                                        {
                                            RoomId = roomId,
                                            ServerType = serverType,
                                            Visible = visible,
                                            RoomData = Converter.Convert(roomData),
                                            JoinData = Converter.Convert(joinData),
                                            IsDevRoom = DevelopmentServer != null
                                        };
            CreateJoinRoomOutput createJoinRoomOutput = _channel.Request<CreateJoinRoomArgs, CreateJoinRoomOutput, PlayerIOError>(27, createJoinRoomArg);
            ServerEndpoint serverEndpoint = DevelopmentServer ?? Converter.Convert(createJoinRoomOutput.Endpoints[0]);
            return new Connection(serverEndpoint, createJoinRoomOutput.JoinKey);
        }

        /// <summary>
        /// Joins a running multiplayer room.
        /// </summary>
        /// <param name="roomId">The ID of the room you wish to join.</param>
        /// <param name="joinData">Data to send to the room with additional information about the join.</param>
        public Connection JoinRoom(string roomId, Dictionary<string, string> joinData = null)
        {
            var joinRoomArg = new JoinRoomArgs
            {
                RoomId = roomId,
                JoinData = Converter.Convert(joinData),
                IsDevRoom = DevelopmentServer != null
            };
            JoinRoomOutput joinRoomOutput = _channel.Request<JoinRoomArgs, JoinRoomOutput, PlayerIOError>(24, joinRoomArg);
            ServerEndpoint serverEndpoint = DevelopmentServer ?? Converter.Convert(joinRoomOutput.Endpoints[0]);
            return new Connection(serverEndpoint, joinRoomOutput.JoinKey);
        }

        /// <summary>
        /// Lists the currently running multiplayer rooms.
        /// </summary>
        /// <param name="roomType">The type of the rooms you wish to list.</param>
        /// <param name="searchCriteria">Only rooms with the same values in their roomData will be returned.</param>
        /// <param name="resultLimit">The maximum amount of rooms you want to receive. Use 0 for 'as many as possible'.</param>
        /// <param name="resultOffset">Defines the index to show results from.</param>
        /// <param name="onlyDevRooms">Set to 'true' to list rooms from the development room list, rather than from the game's global room list.</param>
        public RoomInfo[] ListRooms(string roomType, Dictionary<string, string> searchCriteria = null, int resultLimit = 0, int resultOffset = 0, bool onlyDevRooms = false)
        {
            var listRoomsArg = new ListRoomsArgs
            {
                RoomType = roomType,
                SearchCriteria = Converter.Convert(searchCriteria),
                ResultLimit = resultLimit,
                ResultOffset = resultOffset,
                OnlyDevRooms = onlyDevRooms
            };
            ListRoomsOutput listRoomsOutput = _channel.Request<ListRoomsArgs, ListRoomsOutput, PlayerIOError>(30, listRoomsArg);
            return listRoomsOutput.RoomInfo ?? new RoomInfo[0];
        }
    }
}

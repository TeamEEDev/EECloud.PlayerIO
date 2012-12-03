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
        /// <returns>A new instance of Connection if connecting to the room was successful.</returns>
        public Connection CreateJoinRoom(string roomId, string serverType, bool visible, Dictionary<string, string> roomData, Dictionary<string, string> joinData)
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
        /// <returns>A new instance of Connection if joining the room was successful.</returns>
        public Connection JoinRoom(string roomId, Dictionary<string, string> joinData)
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

        public RoomInfo[] ListRooms(string roomType, Dictionary<string, string> searchCriteria, int resultLimit, int resultOffset, bool onlyDevRooms = false)
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
            return listRoomsOutput.RoomInfo.ToArray();
        }
    }
}

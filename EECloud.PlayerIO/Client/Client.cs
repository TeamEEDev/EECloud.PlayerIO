using System.Collections.Generic;
using EECloud.PlayerIO.Messages;

namespace EECloud.PlayerIO
{
    public class Client
    {
        private readonly HttpChannel _channel;

        private readonly string _connectUserId;

        public ServerEndpoint DevServer;

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

        public Connection CreateJoinRoom(string roomId, string serverType, bool visible, Dictionary<string, string> roomData, Dictionary<string, string> joinData)
        {
            var createJoinRoomArg = new CreateJoinRoomArgs {RoomId = roomId, ServerType = serverType, Visible = visible, RoomData = Converter.Convert(roomData), JoinData = Converter.Convert(joinData), IsDevRoom = DevServer != null};
            CreateJoinRoomOutput createJoinRoomOutput = _channel.Request<CreateJoinRoomArgs, CreateJoinRoomOutput, PlayerIOError>(27, createJoinRoomArg);
            ServerEndpoint devServer = DevServer;
            ServerEndpoint serverEndpoint = devServer;
            if (devServer == null)
            {
                serverEndpoint = Converter.Convert(createJoinRoomOutput.Endpoints[0])
            ;
            }
            return new Connection(serverEndpoint, createJoinRoomOutput.JoinKey);
        }
    }
}

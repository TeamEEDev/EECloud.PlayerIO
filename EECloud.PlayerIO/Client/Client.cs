using System;
using System.Collections.Generic;

namespace EECloud.PlayerIO
{
    public class Client
    {
		private readonly HttpChannel _channel;

		private readonly string _connectUserId;


		public string ConnectUserId
		{
			get
			{
				return _connectUserId;
			}
		}

        private readonly string _token;

        public string Token 
        {
            get { 
                return _token;
            }
        }

        internal Client(HttpChannel channel, string token, string connectUserId)
		{
			channel.SetToken(token);
			_channel = channel;
            _token = token;
			_connectUserId = connectUserId;
		}

        public CreateJoinRoom(string roomId, string serverType, bool visible, Dictionary<string, string> roomData, Dictionary<string, string> joinData, bool isDevRoom)
	    {
		    GClass9.CreateJoinRoomArgs createJoinRoomArg = new GClass9.CreateJoinRoomArgs();
		    createJoinRoomArg.RoomId = roomId;
		    createJoinRoomArg.ServerType = serverType;
		    createJoinRoomArg.Visible = visible;
		    createJoinRoomArg.RoomData = Converter.Convert(roomData);
		    createJoinRoomArg.JoinData = Converter.Convert(joinData);
		    createJoinRoomArg.IsDevRoom = isDevRoom;
		    GClass9.CreateJoinRoomOutput createJoinRoomOutput = this.Call<GClass9.CreateJoinRoomArgs, GClass9.CreateJoinRoomOutput, PlayerIOError>(27, createJoinRoomArg);
		    return createJoinRoomOutput;
	    }
    }
}

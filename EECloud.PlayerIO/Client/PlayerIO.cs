using System;
using System.Security.Cryptography;
using System.Text;
using EECloud.PlayerIO.Messages;

namespace EECloud.PlayerIO
{
    public static class PlayerIO
    {
        private static readonly HttpChannel Channel = new HttpChannel();

        static PlayerIO()
		{

		}

        public static Client Connect(string gameId, string connectionId, string userId, string auth)
        {
            var connectArg = new ConnectArgs
                                 {
                                     UserId = userId,
                                     Auth = auth,
                                     ConnectionId = connectionId,
                                     GameId = gameId
                                 };
            var connectOutput = Channel.Request<ConnectArgs, ConnectOutput, PlayerIOError>(10, connectArg);
            return new Client(Channel, connectOutput.Token, connectOutput.UserId);
        }

        public static string CalcAuth(string userId, string sharedSecret) {
            var unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(sharedSecret)).ComputeHash(Encoding.UTF8.GetBytes(unixTime + ":" + userId));
            return unixTime + ":" + BitConverter.ToString(hmac).Replace("-", "").ToLowerInvariant();
        }

        public static Client FacebookOAuthConnect(string gameId, string accessToken)
        {
            var facebookConnectArg = new FacebookOAuthConnectArgs {GameId = gameId, AccessToken = accessToken};
            var facebookConnectOutput =
                Channel.Request<FacebookOAuthConnectArgs, ConnectOutput, PlayerIOError>(418,
                                                                                        facebookConnectArg);
            return new Client(Channel, facebookConnectOutput.Token, facebookConnectOutput.UserId);
        }

        public static Client SimpleConnect(string gameId, string usernameOrEmail, string password)
        {
            var simpleConnectArg = new SimpleConnectArgs
                                       {
                                           GameId = gameId,
                                           UsernameOrEmail = usernameOrEmail,
                                           Password = password
                                       };
            var simpleConnectOutput =
                Channel.Request<SimpleConnectArgs, ConnectOutput, PlayerIOError>(400,
                                                                                 simpleConnectArg);
            return new Client(Channel, simpleConnectOutput.Token, simpleConnectOutput.UserId);
        }

        public static Client KongregateConnect(string gameId, string userId, string gameAuthToken)
        {
            var kongregateConnectArg = new KongregateConnectArgs
            {
                GameId = gameId,
                UserId = userId,
                GameAuthToken = gameAuthToken
            };
            var kongregateConnectOutput =
                Channel.Request<KongregateConnectArgs, ConnectOutput, PlayerIOError>(400,
                                                                                     kongregateConnectArg);
            return new Client(Channel, kongregateConnectOutput.Token, kongregateConnectOutput.UserId);
        }
    }
}

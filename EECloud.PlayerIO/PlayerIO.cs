using System;
using System.Security.Cryptography;
using System.Text;
using EECloud.PlayerIO.Messages;

namespace EECloud.PlayerIO
{
    /// <summary>
    /// Entry class for the initial connection to Player.IO.
    /// </summary>
    public static class PlayerIO
    {
        private static readonly HttpChannel Channel = new HttpChannel();

        static PlayerIO()
        {
            
        }

        /// <summary>
        /// Connects to a game based on Player.IO as the given user.
        /// </summary>
        /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
        /// <param name="connectionId">The ID of the connection, as given in the settings section of the admin panel. 'public' should be used as the default.</param>
        /// <param name="userId">The ID of the user you wish to authenticate.</param>
        /// <param name="auth">If the connection identified by ConnectionIdentifier only accepts authenticated requests: The auth value generated based on 'userId'.
        /// You can generate an auth value using the CalcAuth() method.</param>
        /// <returns>A new instance of Client if logging in was successful.</returns>
        public static Client Connect(string gameId, string connectionId, string userId, string auth)
        {
            var connectArg = new ConnectArgs
                                 {
                                     GameId = gameId,
                                     ConnectionId = connectionId,
                                     UserId = userId,
                                     Auth = auth
                                 };
            var connectOutput = Channel.Request<ConnectArgs, ConnectOutput, PlayerIOError>(10, connectArg);
            return new Client(Channel, connectOutput.Token, connectOutput.UserId);
        }

        /// <summary>
        /// Calculate an auth hash for use in the Connect method.
        /// </summary>
        /// <param name="userId">The UserID to use when generating the hash</param>
        /// <param name="sharedSecret">The shared secret to use when generating the hash. This must be the same value as the one given to a connection in the admin panel.</param>
        /// <returns>The generated auth hash</returns>
        public static string CalcAuth(string userId, string sharedSecret)
        {
            var unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(sharedSecret)).ComputeHash(Encoding.UTF8.GetBytes(unixTime + ":" + userId));
            return unixTime + ":" + BitConverter.ToString(hmac).Replace("-", "").ToLowerInvariant();
        }

        public static class QuickConnect
        {
            /// <summary>
            /// Connects to a game based on Player.IO as a simple user.
            /// </summary>
            /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
            /// <param name="usernameOrEmail">The username or e-mail address of the user you wish to authenticate.</param>
            /// <param name="password">The password of the user you wish to authenticate.</param>
            /// <returns>A new instance of Client if logging in was successful.</returns>
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

            /// <summary>
            /// Connects to a game based on Player.IO as a Facebook user using a Facebook access token.
            /// </summary>
            /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
            /// <param name="accessToken">The Facebook access token of the user you wish to authenticate.</param>
            /// <returns>A new instance of Client if logging in was successful.</returns>
            public static Client FacebookOAuthConnect(string gameId, string accessToken)
            {
                var facebookConnectArg = new FacebookOAuthConnectArgs { GameId = gameId, AccessToken = accessToken };
                var facebookConnectOutput =
                    Channel.Request<FacebookOAuthConnectArgs, ConnectOutput, PlayerIOError>(418,
                                                                                            facebookConnectArg);
                return new Client(Channel, facebookConnectOutput.Token, facebookConnectOutput.UserId);
            }

            /// <summary>
            /// Connects to a game based on Player.IO as a Kongregate user.
            /// </summary>
            /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
            /// <param name="userId">The Kongregate user ID of the user you wish to authenticate.</param>
            /// <param name="gameAuthToken">The Kongregate auth token of the game you wish to connect to (depends on the user you wish to authenticate).</param>
            /// <returns>A new instance of Client if logging in was successful.</returns>
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
}

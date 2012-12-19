using EECloud.PlayerIO.Messages;

namespace EECloud.PlayerIO
{
    public class QuickConnect
    {
        private readonly HttpChannel _channel;

        internal QuickConnect(HttpChannel channel)
        {
            _channel = channel;
        }

        /// <summary>
        /// Connects to a game based on Player.IO as a simple user.
        /// </summary>
        /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
        /// <param name="usernameOrEmail">The username or e-mail address of the user you wish to authenticate.</param>
        /// <param name="password">The password of the user you wish to authenticate.</param>
        public Client SimpleConnect(string gameId, string usernameOrEmail, string password)
        {
            var simpleConnectArgs = new SimpleConnectArgs
            {
                GameId = gameId,
                UsernameOrEmail = usernameOrEmail,
                Password = password
            };
            var simpleConnectOutput =
                _channel.Request<SimpleConnectArgs, ConnectOutput, PlayerIOError>(400,
                                                                                  simpleConnectArgs);
            return new Client(_channel, simpleConnectOutput.Token, simpleConnectOutput.UserId);
        }

        /// <summary>
        /// Connects to a game based on Player.IO as a Facebook user using a Facebook access token.
        /// </summary>
        /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
        /// <param name="accessToken">The Facebook access token of the user you wish to authenticate.</param>
        public Client FacebookOAuthConnect(string gameId, string accessToken)
        {
            var facebookConnectArgs = new FacebookOAuthConnectArgs { GameId = gameId, AccessToken = accessToken };
            var facebookConnectOutput =
                _channel.Request<FacebookOAuthConnectArgs, ConnectOutput, PlayerIOError>(418,
                                                                                         facebookConnectArgs);
            return new Client(_channel, facebookConnectOutput.Token, facebookConnectOutput.UserId);
        }

        /// <summary>
        /// Connects to a game based on Player.IO as a Kongregate user.
        /// </summary>
        /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
        /// <param name="userId">The Kongregate user ID of the user you wish to authenticate.</param>
        /// <param name="gameAuthToken">The Kongregate auth token of the game you wish to connect to (depends on the user you wish to authenticate).</param>
        public Client KongregateConnect(string gameId, string userId, string gameAuthToken)
        {
            var kongregateConnectArgs = new KongregateConnectArgs
            {
                GameId = gameId,
                UserId = userId,
                GameAuthToken = gameAuthToken
            };
            var kongregateConnectOutput =
                _channel.Request<KongregateConnectArgs, ConnectOutput, PlayerIOError>(400,
                                                                                      kongregateConnectArgs);
            return new Client(_channel, kongregateConnectOutput.Token, kongregateConnectOutput.UserId);
        }

        /// <summary>
        /// Connects to a game based on Player.IO as a Steam user.
        /// </summary>
        /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
        /// <param name="steamAppId">The Steam application ID of the game you wish to connect to.</param>
        /// <param name="steamSessionTicket">The Steam session ticket of the user you wish to authenticate.</param>
        public Client SteamConnect(string gameId, string steamAppId, string steamSessionTicket)
        {
            var steamConnectArgs = new SteamConnectArgs
            {
                GameId = gameId,
                SteamAppId = steamAppId,
                SteamSessionTicket = steamSessionTicket
            };
            var steamConnectOutput =
                _channel.Request<SteamConnectArgs, ConnectOutput, PlayerIOError>(421,
                                                                                 steamConnectArgs);
            return new Client(_channel, steamConnectOutput.Token, steamConnectOutput.UserId);
        }

        public void SimpleRecoverPassword(string gameId, string usernameOrEmail)
        {
            this.Call<identifier39.identifier101, identifier39.identifier104, PlayerIOError>(406, new identifier39.identifier101
            {
                identifier102 = gameId,
                identifier103 = usernameOrEmail
            });
        }
    }
}

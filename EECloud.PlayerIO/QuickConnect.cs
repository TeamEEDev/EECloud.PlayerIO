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
        /// Connects to a game based on Player.IO as a Facebook user using a Facebook access token.
        /// </summary>
        /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
        /// <param name="accessToken">The Facebook access token of the user you wish to authenticate.</param>
        public Client FacebookOAuthConnect(string gameId, string accessToken)
        {
            var facebookConnectArg = new FacebookOAuthConnectArgs { GameId = gameId, AccessToken = accessToken };
            var facebookConnectOutput =
                _channel.Request<FacebookOAuthConnectArgs, ConnectOutput, PlayerIOError>(418,
                                                                                        facebookConnectArg);
            return new Client(_channel, facebookConnectOutput.Token, facebookConnectOutput.UserId);
        }

        /// <summary>
        /// Connects to a game based on Player.IO as a simple user.
        /// </summary>
        /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
        /// <param name="usernameOrEmail">The username or e-mail address of the user you wish to authenticate.</param>
        /// <param name="password">The password of the user you wish to authenticate.</param>
        public Client SimpleConnect(string gameId, string usernameOrEmail, string password)
        {
            var simpleConnectArg = new SimpleConnectArgs
            {
                GameId = gameId,
                UsernameOrEmail = usernameOrEmail,
                Password = password
            };
            var simpleConnectOutput =
                _channel.Request<SimpleConnectArgs, ConnectOutput, PlayerIOError>(400,
                                                                                 simpleConnectArg);
            return new Client(_channel, simpleConnectOutput.Token, simpleConnectOutput.UserId);
        }

        /// <summary>
        /// Connects to a game based on Player.IO as a Kongregate user.
        /// </summary>
        /// <param name="gameId">The ID of the game you wish to connect to. This value can be found in the admin panel.</param>
        /// <param name="userId">The Kongregate user ID of the user you wish to authenticate.</param>
        /// <param name="gameAuthToken">The Kongregate auth token of the game you wish to connect to (depends on the user you wish to authenticate).</param>
        public Client KongregateConnect(string gameId, string userId, string gameAuthToken)
        {
            var kongregateConnectArg = new KongregateConnectArgs
            {
                GameId = gameId,
                UserId = userId,
                GameAuthToken = gameAuthToken
            };
            var kongregateConnectOutput =
                _channel.Request<KongregateConnectArgs, ConnectOutput, PlayerIOError>(400,
                                                                                     kongregateConnectArg);
            return new Client(_channel, kongregateConnectOutput.Token, kongregateConnectOutput.UserId);
        }
    }
}

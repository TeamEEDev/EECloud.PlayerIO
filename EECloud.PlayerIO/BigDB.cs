using EECloud.PlayerIO.Helpers;
using EECloud.PlayerIO.Messages;

namespace EECloud.PlayerIO
{
    public class BigDB
    {
        private const string PlayerObjectsTableName = "PlayerObjects";

        private readonly HttpChannel _channel;

        internal BigDB(HttpChannel channel)
        {
            _channel = channel;
        }

        public DatabaseObject LoadMyPlayerObject()
        {
            var loadMyPlayerObjectOutput = _channel.Request<NoArgsOrOutput, LoadMyPlayerObjectOutput, PlayerIOError>(103, new NoArgsOrOutput());
            loadMyPlayerObjectOutput.PlayerObject.Table = PlayerObjectsTableName;
            return loadMyPlayerObjectOutput.PlayerObject;
        }
    }
}

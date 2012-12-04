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
            var loadMyPlayerObjectOutput = _channel.Request<LoadMyPlayerObjectArgs, LoadMyPlayerObjectOutput, PlayerIOError>(103, new LoadMyPlayerObjectArgs());
            loadMyPlayerObjectOutput.PlayerObject.Table = PlayerObjectsTableName;
            return loadMyPlayerObjectOutput.PlayerObject;
        }
    }
}

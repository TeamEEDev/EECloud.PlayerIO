using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    public class FacebookOAuthConnectArgs
    {
        [ProtoMember(1)]
        public string GameId
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string AccessToken
        {
            get;
            set;
        }
    }
}

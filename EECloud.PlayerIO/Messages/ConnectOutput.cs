using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
	[ProtoContract]
	internal class ConnectOutput
	{
		[ProtoMember(4)]
		public string GameFSRedirectMap
		{
			get;
			set;
		}

		[ProtoMember(3)]
		public bool ShowBranding
		{
			get;
			set;
		}

		[ProtoMember(1)]
		public string Token
		{
			get;
			set;
		}

		[ProtoMember(2)]
		public string UserId
		{
			get;
			set;
		}
	}
}

namespace EECloud.PlayerIO
{
    public sealed class ServerEndpoint
    {
        public string Address
        {
            get;
            private set;
        }

        public int Port
        {
            get;
            private set;
        }

        public ServerEndpoint(string address, int port)
        {
            Address = address;
            Port = port;
        }
    }
}

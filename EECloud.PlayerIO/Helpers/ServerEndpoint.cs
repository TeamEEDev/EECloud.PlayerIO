using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            this.Address = address;
            this.Port = port;
        }
    }
}

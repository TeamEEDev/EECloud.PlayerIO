using System.Collections.Generic;
using ProtoBuf;

namespace EECloud.PlayerIO.Helpers
{
    [ProtoContract]
    public class DatabaseObject
    {
        public string Table
        {
            get;
            set;
        }

        [ProtoMember(1)]
        public string Key
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string Version
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public KeyValuePair<string, string>[] Core
        {
            get;
            set;
        }

        //[ProtoMember(4)]
        //public uint identifier310
        //{
        //    get;
        //    set;
        //}
    }
}

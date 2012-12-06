using System.Collections.Generic;
using System.Linq;
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

        public object Item(string propertyExpression)
        {
            object output = (from kvp in Core where kvp.Key == propertyExpression select kvp.Value).FirstOrDefault();
            return output;
        }

        //[ProtoMember(4)]
        //public uint identifier310
        //{
        //    get;
        //    set;
        //}
    }
}

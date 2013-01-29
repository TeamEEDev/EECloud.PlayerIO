using System.Collections.Generic;
using System.Linq;
using EECloud.PlayerIO.Messages;
using ProtoBuf;

namespace EECloud.PlayerIO.Helpers
{
    [ProtoContract]
    public class DatabaseObject
    {
        public string Table { get; internal set; }

        [ProtoMember(1)]
        public string Key { get; set; }

        [ProtoMember(2)]
        public string Version { get; set; }

        [ProtoMember(3)]
        private KeyValuePair<string, DbObjValue>[] Properties { get; set; }

        public object Item(string propertyExpression)
        {
            if (Properties != null)
            {
                var output = (from kvp in Properties where kvp.Key == propertyExpression select kvp.Value).FirstOrDefault();
                if (output != null) return output.GetRealValue();
            }

            return null;
        }

        //[ProtoMember(4)]
        //public uint Creator { get; set; }
    }
}

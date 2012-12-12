using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EECloud.PlayerIO.Messages;
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
        private KeyValuePair<string, DbObjValue>[] Core
        {
            get;
            set;
        }

        public object Item(string propertyExpression)
        {
            var output = (from kvp in Core where kvp.Key == propertyExpression select kvp.Value).FirstOrDefault();

            return output != null ? output.GetRealValue() : null;
        }

        //[ProtoMember(4)]
        //public uint identifier310
        //{
        //    get;
        //    set;
        //}
    }
}

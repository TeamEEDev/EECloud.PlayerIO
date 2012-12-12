using System;
using System.Collections.Generic;
using ProtoBuf;

namespace EECloud.PlayerIO.Messages
{
    [ProtoContract]
    internal class DbObjValue
    {
        public object GetRealValue()
        {
            switch (Type)
            {
                case DbObjType.String:
                    return ValueString;
                case DbObjType.Int:
                    return ValueInteger;
                case DbObjType.UInt:
                    return ValueUInteger;
                case DbObjType.Long:
                    return ValueLong;
                case DbObjType.Float:
                    return ValueFloat;
                case DbObjType.Double:
                    return ValueDouble;
                case DbObjType.ByteArray:
                    return ValueByteArray;
                case DbObjType.DateTime:
                    return DateTime.FromFileTimeUtc(ValueDateTime);
                case DbObjType.Array:
                    return ValueArray;
                case DbObjType.Obj:
                    return ValueObject;
            }

            return null;
        }

        [ProtoMember(1)]
        public DbObjType Type
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string ValueString
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public int ValueInteger
        {
            get;
            set;
        }
        
        [ProtoMember(4)]
        public uint ValueUInteger
        {
            get;
            set;
        }

        [ProtoMember(5)]
        public long ValueLong
        {
            get;
            set;
        }

        [ProtoMember(6)]
        public bool ValueBoolean
        {
            get;
            set;
        }

        [ProtoMember(7)]
        public float ValueFloat
        {
            get;
            set;
        }

        [ProtoMember(8)]
        public double ValueDouble
        {
            get;
            set;
        }

        [ProtoMember(9)]
        public byte[] ValueByteArray
        {
            get;
            set;
        }

        [ProtoMember(10)]
        public long ValueDateTime
        {
            get;
            set;
        }

        [ProtoMember(11)]
        public List<DbObjValue> ValueArray
        {
            get;
            set;
        }

        [ProtoMember(12)]
        public DbObjValue ValueObject
        {
            get;
            set;
        }
    }
}

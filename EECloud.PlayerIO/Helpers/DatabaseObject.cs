using System;
using System.Collections.Generic;
using System.IO;
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
            var output = (from kvp in Core where kvp.Key == propertyExpression select kvp.Value).FirstOrDefault();

            if (output != null)
            {
                switch ((byte)output[0])
                {
                    case 8:
                        //var oput = 0;
                        //for (var i = 2; i < output.Length - 1; i++)
                        //{
                        //    oput += output[i] << ((i - 2) * 8);
                        //}
                        switch ((byte)output[1])
                        {
                            case 1: // Integer
                                return Decoder.ReadInteger(output.Substring(2));
                                break;
                            case 2: // UInteger
                                break;
                            case 3: // Long
                                break;
                                return Int64.Parse(output.Substring(2));
                            case 4: // Boolean
                                break;
                            case 5: // Float
                                return Decoder.ReadFloat(output.Substring(2));
                            case 6: // Double
                                break;
                            case 7: // ByteArray
                                break;
                            case 8: // DateTime
                                break;
                        }
                        break;
                    case 18: // String/Array/Object
                        return output.Length > 1 ? output.Substring(2, output[1]) : null;
                }
            }

            return output;
        }

        private static class Decoder
        {
            public static int ReadInteger(string input)
            {
                return ProtoReader.DirectReadVarintInt32(GenerateStreamFromString(input));
            }

            public static float ReadFloat(string input)
            {
                var littleEndianInt32 = ProtoReader.DirectReadLittleEndianInt32(GenerateStreamFromString(input));
                return BitConverter.ToSingle(BitConverter.GetBytes(littleEndianInt32), 0);
            }
        }

        public static Stream GenerateStreamFromString(string input)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(input);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        //[ProtoMember(4)]
        //public uint identifier310
        //{
        //    get;
        //    set;
        //}
    }
}

using System.Collections.Generic;
using System.Linq;
using EECloud.PlayerIO.Messages;

namespace EECloud.PlayerIO
{
    internal static class Converter
    {
        internal static KeyValuePair[] Convert(Dictionary<string, string> dict)
        {
            var keyValuePairs = new List<KeyValuePair>();
            if (dict != null)
            {
                keyValuePairs.AddRange(dict.Select(keyValuePair => new KeyValuePair {Key = keyValuePair.Key, Value = keyValuePair.Value}));
            }
            return keyValuePairs.ToArray();
        }

        internal static Dictionary<string, string> Convert(KeyValuePair[] keyValuePair)
        {
            var strs = new Dictionary<string, string>();
            if (keyValuePair != null)
            {
                foreach (var valuePair in keyValuePair)
                {
                    strs[valuePair.Key] = valuePair.Value;
                }
            }
            return strs;
        }

        internal static ServerEndpoint Convert(Messages.ServerEndpoint serverEndpoint)
        {
            return new ServerEndpoint(serverEndpoint.Address, serverEndpoint.Port);
        }
    }
}

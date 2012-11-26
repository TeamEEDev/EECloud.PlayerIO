using System.Collections.Generic;

namespace EECloud.PlayerIO
{
    /// <summary>
    /// Represents a message sent between the client and the server.
    /// <para>A message consists of a type (string), and zero or more parameters that are supported.</para>
    /// </summary>
    public class Message
    {
        public string Type;
        private readonly Dictionary<object, byte> parameters = new Dictionary<object, byte>();

        public uint Count
        {
            get { return (uint)parameters.Count; }
        }

        /// <summary>Creates a new Message.</summary>
        /// <param name="type">The type of message to create.</param>
        /// <param name="parameters">A list of the data to add to the message.</param>
        /// <returns></returns>
        public static Message Create(string type, params object[] parameters)
        {
            
        }
    }
}

using System;
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
        private readonly List<Tuple<object, MessageType>> _parameters = new List<Tuple<object, MessageType>>();
        public object[] Parameters
        {
            get
            {
                var output = new object[_parameters.Count - 1];
                for (int i = 0; i < _parameters.Count; i++)
                {
                    output[i] = _parameters[i].Item1;
                }
                return output;
            }
        }
        public int Count
        {
            get { return _parameters.Count; }
        }

        public Message(string type, params object[] parameters)
        {
            Type = type;
            Add(parameters);
        }

        /// <summary>Creates a new Message.</summary>
        /// <param name="type">The type of message to create.</param>
        /// <param name="parameters">A list of the data to add to the message.</param>
        /// <returns></returns>
        public static Message Create(string type, params object[] parameters)
        {
            return new Message(type, parameters);
        }

        public void Add(params object[] parameters)
        {
            foreach (object obj in parameters)
            {
                if (obj == null)
                {
                    throw new ArgumentNullException("Can't add null values to Player.IO Messages.");
                }
                if (obj is string)
                {
                    _parameters.Add(Tuple.Create(obj, MessageType.String));
                }
                else if (obj is int)
                {
                    _parameters.Add(Tuple.Create(obj, MessageType.Integer));
                }
                else if (obj is bool)
                {
                    _parameters.Add(Tuple.Create(obj, MessageType.Boolean));
                }
                else if (obj is float)
                {
                    _parameters.Add(Tuple.Create(obj, MessageType.Float));
                }
                else if (obj is double)
                {
                    _parameters.Add(Tuple.Create(obj, MessageType.Double));
                }
                else if (obj is byte[])
                {
                    _parameters.Add(Tuple.Create(obj, MessageType.ByteArray));
                }
                else if (obj is uint)
                {
                    _parameters.Add(Tuple.Create(obj, MessageType.UInteger));
                }
                else if (obj is long)
                {
                    _parameters.Add(Tuple.Create(obj, MessageType.Long));
                }
                else if (!(obj is ulong))
                {
                    throw new InvalidOperationException(
                        "Player.IO Messages only support objects of types: String, Integer, Boolean, Float, Double, Byte[], UInteger, Long & ULong. Type '" +
                        obj.GetType().FullName + "' is not supported.");
                }
                _parameters.Add(Tuple.Create(obj, MessageType.ULong));
            }
        }

        /*public string ToString()
        {
            
        }*/
    }
}

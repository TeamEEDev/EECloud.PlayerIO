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
                var output = new object[_parameters.Count];
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

        #region Get
        public string GetString(int index)
        {
            return (string)_parameters[index].Item1;
        }
        public int GetInteger(int index)
        {
            return (int)_parameters[index].Item1;
        }
        public uint GetUInteger(int index)
        {
            return (uint)_parameters[index].Item1;
        }
        public long GetLong(int index)
        {
            return (long)_parameters[index].Item1;
        }
        public ulong GetULong(int index)
        {
            return (ulong)_parameters[index].Item1;
        }
        public byte[] GetByteArray(int index)
        {
            return (byte[])_parameters[index].Item1;
        }
        public float GetFloat(int index)
        {
            return (float)_parameters[index].Item1;
        }
        public double GetDouble(int index)
        {
            return (double)_parameters[index].Item1;
        }
        public bool GetBoolean(int index)
        {
            return (bool)_parameters[index].Item1;
        }
        #endregion

        #region Add
        public void Add(string parameter)
        {
            _parameters.Add(Tuple.Create((object)parameter, MessageType.String));
        }
        public void Add(int parameter)
        {
            _parameters.Add(Tuple.Create((object)parameter, MessageType.Integer));
        }
        public void Add(uint parameter)
        {
            _parameters.Add(Tuple.Create((object)parameter, MessageType.UInteger));
        }
        public void Add(long parameter)
        {
            _parameters.Add(Tuple.Create((object)parameter, MessageType.Long));
        }
        public void Add(ulong parameter)
        {
            _parameters.Add(Tuple.Create((object)parameter, MessageType.ULong));
        }
        public void Add(byte[] parameter)
        {
            _parameters.Add(Tuple.Create((object)parameter, MessageType.ByteArray));
        }
        public void Add(float parameter)
        {
            _parameters.Add(Tuple.Create((object)parameter, MessageType.Float));
        }
        public void Add(double parameter)
        {
            _parameters.Add(Tuple.Create((object)parameter, MessageType.Double));
        }
        public void Add(bool parameter)
        {
            _parameters.Add(Tuple.Create((object)parameter, MessageType.Boolean));
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
                else if (obj is ulong)
                {
                    _parameters.Add(Tuple.Create(obj, MessageType.ULong));
                }
                else
                {
                    throw new InvalidOperationException(
                        "Player.IO Messages only support objects of types: String, Integer, Boolean, Float, Double, Byte[], UInteger, Long & ULong. Type '" +
                        obj.GetType().FullName + "' is not supported.");
                }
            }
        }
        #endregion

        /*public string ToString()
        {
            
        }*/
    }
}

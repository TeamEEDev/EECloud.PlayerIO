using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EECloud.PlayerIO
{
    /// <summary>
    /// Represents a message sent between the client and the server.
    /// <para>A message consists of a type (string), and zero or more parameters that are supported.</para>
    /// </summary>
    public class Message : IEnumerable<object>
    {
        /// <summary>Creates a new Message.</summary>
        /// <param name="type">The type of message to create.</param>
        /// <param name="parameters">A list of the data to add to the message.</param>
        public Message(string type, params object[] parameters)
        {
            Type = type;
            Add(parameters);
        }

        public string Type { get; private set; }
        private readonly List<Tuple<object, MessageType>> _parameters = new List<Tuple<object, MessageType>>();

        public int Count
        {
            get { return _parameters.Count; }
        }

        #region Get
        public object Item(int index)
        {
            return _parameters[index].Item1;
        }

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
        private const string ParameterNullText = "Can't add null values to Player.IO Messages.";

        public void Add(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(ParameterNullText);
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
                    "Player.IO Messages only support objects of types: String, Integer, Boolean, Float, Double, Byte[], UInteger, Long & ULong." + Environment.NewLine +
                    "Type '" + obj.GetType().FullName + "' is not supported.");
            }
        }

        public void Add(params object[] parameters)
        {
            foreach (var obj in parameters)
            {
                Add(obj);
            }
        }

        #region Separate methods for allowed object types
        public void Add(string parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", ParameterNullText);
            }
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
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter", ParameterNullText);
            }
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
        #endregion
        #endregion

        public override string ToString()
        {
            string output = "Message.Type = " + Type + Environment.NewLine +
                "Message.Parameters";
            for (var i = 0; i < _parameters.Count; i++)
            {
                output += Environment.NewLine +
                    "  [" + i + "] (" + _parameters[i].Item1.GetType().Name + ") = " +
                    _parameters[i].Item1;
            }
            return output;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return _parameters.Select(t => t.Item1).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Yubaba.Uno.Services
{
    public class Message
    {
        public Message(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}

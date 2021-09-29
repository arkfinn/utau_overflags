using System;
using System.Text;

namespace Utau.Domain.Flags.FlagTypes
{
    internal class Flag : IFlag
    {
        public string Key { get; }

        public int Value { get; }

        public Flag(string key, int value)
        {
            Key = key ?? throw new ArgumentNullException();
            Value = value;
        }

        public void AppendAttribute(StringBuilder target)
        {
            target.Append(Key);
            target.Append(Value);
        }

        public string ToAttribute()
        {
            return Key + Value;
        }
    }
}
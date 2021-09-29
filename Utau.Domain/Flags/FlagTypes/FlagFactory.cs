using System;

namespace Utau.Domain.Flags.FlagTypes
{
    public class FlagFactory
    {
        private readonly FlagRule rule = new FlagRule();

        public IFlag CreateFlag(string key, string valueText)
        {
            if (!int.TryParse(valueText, out int value))
            {
                throw new ArgumentException(valueText + " is invalid value.");
            }
            return CreateFlag(key, value);
        }

        public IFlag CreateFlag(string key, int value)
        {
            if (rule.IsNoValueKey(key))
            {
                return CreateNoValueFlag(key);
            }
            return new Flag(key, value);
        }

        public IFlag CreateNoValueFlag(string key)
        {
            switch (key)
            {
                case "N":
                    return new FlagNoFormantFilter();

                default:
                    throw new ArgumentException("Flag(" + key + ") is not no value flag.");
            }
        }
    }
}
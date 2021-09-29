using System.Collections.Generic;
using System.Text;
using Utau.Domain.Flags.FlagTypes;

namespace Utau.Domain.Flags
{
    public class FlagList
    {
        private IDictionary<string, IFlag> Dictionary;

        public FlagList(IDictionary<string, IFlag> dictionary)
        {
            Dictionary = dictionary;
        }

        public IFlag this[string index]
        {
            get
            {
                return Dictionary[index];
            }
        }

        public string ToAttribute()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var flag in Dictionary.Values)
            {
                flag.AppendAttribute(sb);
            }
            return sb.ToString();
        }

        public IDictionary<string, IFlag> ToDictionary()
        {
            return new Dictionary<string, IFlag>(Dictionary);
        }

        public FlagList Merge(FlagList flags)
        {
            var list = flags.ToDictionary();
            foreach (KeyValuePair<string, IFlag> var in Dictionary)
            {
                list[var.Key] = var.Value;
            }
            return new FlagList(list);
        }
    }
}
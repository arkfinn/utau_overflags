using System.Collections.Generic;
using Utau.Domain.Flags;
using Utau.Domain.Flags.FlagTypes;
using Utau.OverFlags.Domain.CalculateCommands;

namespace Utau.OverFlags.Domain.Flags
{
    public class FlagCalculatePlan
    {
        private Dictionary<string, CalculateCommand> list = new Dictionary<string, CalculateCommand>();

        public void Add(string flagName, CalculateCommand calc)
        {
            list.Add(flagName, calc);
        }

        public CalculateCommand this[string index]
        {
            get
            {
                return list[index];
            }
        }

        public Dictionary<string, CalculateCommand>.Enumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }

        internal bool ContainsKey(string p)
        {
            return list.ContainsKey(p);
        }

        private readonly FlagFactory factory = new FlagFactory();

        public FlagList Calculate(FlagList flags)
        {
            var resultList = flags.ToDictionary();
            foreach (KeyValuePair<string, CalculateCommand> var in list)
            {
                int def = (resultList.ContainsKey(var.Key)) ? resultList[var.Key].Value : 0;
                resultList[var.Key] = factory.CreateFlag(var.Key, var.Value.Calculate(def));
            }
            return new FlagList(resultList);
        }

        public override string ToString()
        {
            return ToString(true);
        }

        public string ToString(bool forMath)
        {
            string res = "";
            foreach (KeyValuePair<string, CalculateCommand> var in list)
            {
                res += var.Key + var.Value.ToShortString(forMath);
            }
            return res;
        }
    }
}
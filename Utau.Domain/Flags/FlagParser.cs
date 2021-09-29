using System.Collections.Generic;
using System.Globalization;
using Utau.Domain.Flags.FlagTypes;

namespace Utau.Domain.Flags
{
    public class FlagParser
    {
        private readonly FlagRule rule = new FlagRule();
        private readonly FlagFactory factory = new FlagFactory();

        public FlagList Parse(string s)
        {
            string key = "";
            string val = "";
            bool keymode = true;
            var charEnum = StringInfo.GetTextElementEnumerator(s);
            var list = new Dictionary<string, IFlag>();

            while (charEnum.MoveNext())
            {
                string c = (string)charEnum.Current;
                if (keymode)
                {
                    if (rule.IsValueLetter(c))
                    {
                        val = c;
                        keymode = false;
                        continue;
                    }
                    if (rule.IsNoValueKey(key))
                    {
                        list.Add(key, factory.CreateNoValueFlag(key));
                        key = c;
                    }
                    else
                    {
                        key = key + c;
                    }
                }
                else
                {
                    if (rule.IsValueLetter(c))
                    {
                        val = val + c;
                        continue;
                    }
                    list.Add(key, factory.CreateFlag(key, val));
                    key = c;
                    val = "";
                    keymode = true;
                }
            }
            if (!keymode)
            {
                list.Add(key, factory.CreateFlag(key, val));
            }
            else if (rule.IsNoValueKey(key))
            {
                list.Add(key, factory.CreateNoValueFlag(key));
            }
            return new FlagList(list);
        }
    }
}
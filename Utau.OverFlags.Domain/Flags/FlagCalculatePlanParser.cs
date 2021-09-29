using System.Globalization;
using Utau.Domain.Flags;
using Utau.OverFlags.Domain.CalculateCommands;

namespace Utau.OverFlags.Domain.Flags
{
    public class FlagCalculatePlanParser
    {
        private readonly FlagRule rule = new FlagRule();
        private readonly CalculatorFactory factory = new CalculatorFactory();

        public FlagCalculatePlan Parse(string s)
        {
            FlagCalculatePlan d = new FlagCalculatePlan();
            string key = "";
            string val = "";
            bool keymode = true;
            var charEnum = StringInfo.GetTextElementEnumerator(s);
            var op = "";
            while (charEnum.MoveNext())
            {
                string c = (string)charEnum.Current;
                if (IsCalculator(c))
                {
                    op = c;
                    continue;
                }
                if (keymode)
                {
                    if (rule.IsValueLetter(c))
                    {
                        val = c;
                        keymode = false;
                        continue;
                    }
                    // overflags計算記法では「N」フラグのような値をもたないフラグは許容しない。
                    key = key + c;
                }
                else
                {
                    if (rule.IsValueLetter(c))
                    {
                        val = val + c;
                        continue;
                    }
                    d.Add(key, factory.Create(op, val));
                    key = c;
                    val = "";
                    op = "";
                    keymode = true;
                }
            }
            if (!keymode)
            {
                d.Add(key, factory.Create(op, val));
            }
            return d;
        }

        private bool IsCalculator(string op)
        {
            return (op == "+" || op == "-" || op == "%");
        }
    }
}
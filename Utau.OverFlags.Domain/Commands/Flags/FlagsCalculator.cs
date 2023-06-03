using Utau.Domain.Flags;
using Utau.OverFlags.Domain.Flags;

namespace Utau.OverFlags.Domain.Commands.Flags
{
    public class FlagsCalculator : FlagsCommand
    {
        protected FlagsCalculator() : base()
        {
        }

        public FlagsCalculator(string p) : base(p)
        {
        }

        public override FlagCalculatePlan CreatePlan()
        {
            return new FlagCalculatePlanParser().Parse(Plan);
        }

        public override FlagList Edit(FlagList baseList)
        {
            return CreatePlan().Calculate(baseList);
        }

        internal const string MethodText = "で計算";

        public override string Method
        {
            get { return MethodText; }
        }
    }
}
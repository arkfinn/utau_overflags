using Utau.Domain.Flags;
using Utau.OverFlags.Domain.Flags;

namespace Utau.OverFlags.Domain.Commands.Flags
{
    public class FlagsReplacer : FlagsCommand
    {
        protected FlagsReplacer() : base()
        {
        }

        public FlagsReplacer(string p) : base(p)
        {
        }

        public override FlagCalculatePlan CreatePlan()
        {
            return new FlagCalculatePlanParser().Parse(Plan);
        }

        public override FlagList Edit(FlagList baseList)
        {
            return new FlagParser().Parse(Plan).Merge(baseList);
        }

        internal const string MethodText = "で置換";

        public override string Method
        {
            get { return MethodText; }
        }
    }
}
using Utau.Domain.Flags;
using Utau.OverFlags.Domain.Flags;

namespace utau_overflags.Attributes.Flags.EditTypes
{
    public class FlagsReplacer : EditType
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